using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using PagoAgilFrba.Sucursal;
using System.Configuration;
namespace PagoAgilFrba
{
    public class BD
    {
        private static SqlTransaction trans;
        private static String connectionString = ConfigurationManager.AppSettings["conexionSQL"];
        private static SqlConnection con = new SqlConnection(connectionString);
        public static SqlConnection getConnection()
        {
            return con;
        }
        public static DateTime fechaActual()
        {
            return DateTime.ParseExact(ConfigurationManager.AppSettings["fechaSistema"], "yyyy-MM-dd hh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public static Byte[] sha256_hash(String value)
        {

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                return hash.ComputeHash(enc.GetBytes(value));
            }

        }

        internal static bool autenticacionCorrecta(string username, string password)
        {
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand("SELECT usuario_nombre, usuario_contrasena,usuario_cantidadDeIntentos FROM EL_JAPONES_SANGRANDO.Usuarios WHERE usuario_nombre=@username");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombreUsuario = null;
            byte[] dbPassword = null;
            int intentosFallidos = 0;
            while (reader.Read())
            {
                nombreUsuario = reader["usuario_nombre"].ToString();
                dbPassword = reader.GetSqlBytes(reader.GetOrdinal("usuario_contrasena")).Buffer;
                intentosFallidos = reader.GetInt32(reader.GetOrdinal("usuario_cantidadDeIntentos"));
            }
            reader.Close();
            connection.Close();
            if (nombreUsuario != null)
            {
                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Usuario esta bloqueado", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (!sha256_hash(password).SequenceEqual(dbPassword)){
                    intentosFallidos++;
                    BD.modificarNumeroDeIntentosPorUsuario(username, intentosFallidos);

                    if(intentosFallidos>=3){

                        MessageBox.Show("Usuario se bloqueo", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else{
                        MessageBox.Show("Contraseña erronea", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else{
                    BD.modificarNumeroDeIntentosPorUsuario(username, 0);
                    return true;
                }
            }
            else{
                MessageBox.Show("Invalid username", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            return false;

        }

        internal static int cantidadDeVecesPorUsuario(string username)
        {
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand("SELECT usuario_cantidadDeIntentos FROM EL_JAPONES_SANGRANDO.Usuarios WHERE usuario_nombre=@username");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            string cantidadDeVeces = "0";
            while (reader.Read())
            {
                cantidadDeVeces = reader["usuario_nombre"].ToString();
            }
            reader.Close();
            connection.Close();

            return Int32.Parse(cantidadDeVeces);
        }

        public static List<String> roles(string username)
        {
            List<String> listaRoles = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand("SELECT rol_nombre FROM EL_JAPONES_SANGRANDO.Roles JOIN EL_JAPONES_SANGRANDO.Usuario_Rol on rol_nombre=usuario_Rol_rol WHERE Usuario_Rol_usuario=@username and rol_estado=1");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombreUsuario = null;
            byte[] dbPassword = null;
            while (reader.Read())
            {
                listaRoles.Add(reader[0].ToString());
            }
            reader.Close();
            connection.Close();
            return listaRoles;
        }

        public static List<String> listaDeUnCampo(string query)
        {
            List<String> listaRoles = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand(query);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            while (reader.Read())
            {
                listaRoles.Add(reader[0].ToString());
            }
            reader.Close();
            connection.Close();
            return listaRoles;
        }

        public static DataTable busqueda(string query)
        {
            var command = new SqlCommand(query);
            return busqueda(command);
        }
        public static String devolverColumna(DataTable tabla,string atributo)
        {

            return tabla.Rows[0][atributo].ToString();
        }

        public static DataTable busqueda(SqlCommand command)
        {
            var ds = new DataTable();

            SqlConnection connection = getConnection();
            connection.Open();

            command.Connection = connection;

            var adapter = new SqlDataAdapter(command);
            var commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Fill(ds);
            connection.Close();
            return ds;
        }
        public static void modificarNumeroDeIntentosPorUsuario(string username, int numeroDeIntentos)
        {
          
         SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("UPDATE EL_JAPONES_SANGRANDO.Usuarios SET usuario_cantidadDeIntentos = @cantidad WHERE usuario_nombre = @usuario_nombre");
            query.Parameters.AddWithValue("usuario_nombre",username);

            query.Parameters.AddWithValue("cantidad", numeroDeIntentos);
            query.Connection = connection;
            query.ExecuteNonQuery();
            connection.Close();
        }    

        public static void crearRol(string rol)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("INSERT INTO EL_JAPONES_SANGRANDO.Roles(rol_nombre)values(@rol)");
            query.Parameters.AddWithValue("rol",rol);
            query.Connection = connection;
            query.ExecuteNonQuery();
            connection.Close();
        }

        public static void asignarFuncionalidadAlRol(string rol,string funcionalidadId)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("INSERT INTO EL_JAPONES_SANGRANDO.[Rol_Funcionalidad](rol_Funcionalidad_rol,rol_Funcionalidad_funcionalidad)values(@rol,@funcionalidad)");
            query.Parameters.AddWithValue("rol", rol);
            query.Parameters.AddWithValue("funcionalidad", funcionalidadId);

            query.Connection = connection;
            query.ExecuteNonQuery();
            connection.Close();
        }

        public static int ABM(string query)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand command = new SqlCommand(query);
            command.Connection = connection;
            int x;
            try
            {
            x =command.ExecuteNonQuery();

            }
           catch (Exception ex){
               x = 0;
            }
            connection.Close();
            return x;
        }
        public static void commit()
        {
            trans.Commit();
            con.Close();
        }

        public static void rollback()
        {
            trans.Rollback();
            con.Close();
        }

        public static void beginTrans()
        {
            con.Open();
            trans = getConnection().BeginTransaction();
        }
        public static void correrEnTransaccion(SqlCommand query)
        {
            SqlConnection connection = getConnection();
            query.Transaction = trans;
            query.Connection = connection;
            query.ExecuteNonQuery();

        }
        public static int correrStoreProcedure(List<String> listaDeValores)
        {
            

            BD.beginTrans();
            String y = "";
            listaDeValores.ForEach(delegate(String name)
            {
                y += name + ";";
            });

            SqlCommand command = new SqlCommand(y);

            int x = 1;
            try
            {
                BD.correrEnTransaccion(command);
                BD.commit();

            }
            catch (Exception ex)
            {
                BD.rollback();
                x = 0;
            }
            return x;
        }

        public static int insert(String tabla, String query)
        {
            return BD.ABM("INSERT into EL_JAPONES_SANGRANDO." + tabla + " "+ query);
        }

        public static int update(String tabla, String query)
        {
            return BD.ABM("UPDATE EL_JAPONES_SANGRANDO." + tabla + " SET "+ query);
        }

        public static string consultaDeUnSoloResultado(string query)
        {
            try{

            return BD.listaDeUnCampo(query)[0];
                }
            catch (Exception ex){
                return "";
            }
        }

        public static sucursal devolverSucursal(String sucursalNombre){
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand("SELECT * FROM EL_JAPONES_SANGRANDO.Sucursales WHERE sucursal_nombre=@sucursal_nombre");
            loginCommand.Parameters.AddWithValue("sucursal_nombre", sucursalNombre);
            loginCommand.Connection = connection;

            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombre = null;
            String direccion = null;
            int codigo = 0;
            bool habilitado = false;
          
            while (reader.Read())
            {
                nombre = reader["sucursal_nombre"].ToString();
                direccion = reader["sucursal_direccion"].ToString();
                codigo = Int32.Parse(reader["sucursal_codigo_postal"].ToString());
                habilitado = reader.GetBoolean(3);
            }
            sucursal sucursal = new sucursal(nombre, codigo, direccion, habilitado);
            reader.Close();
            connection.Close();
            return sucursal;
        }

        public static void nuevoBoton(DataGridView gdv, String nombre, int index)
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.Name = nombre;
                buttons.DataPropertyName = nombre;
                buttons.HeaderText = nombre;
                buttons.Text = nombre;
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = index;
            }
            gdv.Columns.Add(buttons);
        }


        internal static bool todasRendidas(string empresa_cuit)
        {
            string query = "select count(*) from EL_JAPONES_SANGRANDO.Facturas where factura_estado = 2 AND factura_empresa = '" + empresa_cuit + "'";
            return Int32.Parse(consultaDeUnSoloResultado(query)) == 0;
        }

        static string usuario2 = "";

        public static void setUsuario(string usuario_)
        {
            usuario2 = usuario_;
        }

        public static string getUsuario()
        {
            return usuario2;
        }

        static string sucursal2 = "";

        public static void setSucursal(string sucursal_)
        {
            sucursal2 = sucursal_;
        }

        public static string getSucursal()
        {
            return sucursal2;
        }
       
  
        public static bool modificarCliente(string telefono, string direccion, string codigoPostal, string mail, string nombre, string apellido, string fechaVenc, string DNI,bool b1)
        {
            int x = b1 ? 1 : 0;
            if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Clientes SET cliente_direccion = '" +direccion +
                "',cliente_codigo_postal = '" + codigoPostal +
                "',cliente_mail = '" +mail +
                "',cliente_telefono = '" + telefono +
                "',cliente_nombre = '" + nombre +
                "',cliente_apellido = '" + apellido +
                "',cliente_fecha_nacimiento = '" + fechaVenc +
                "',cliente_estado = '" + x +
                "' WHERE cliente_DNI = '" + DNI + "'") > 0)
            {
                
                MessageBox.Show("Se pudo modificar el cliente", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Error en los datos", "Error en la modificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static DataTable filtroClienteEliminar(string nombre, string apellido, string dni)
        {
            String query = "SELECT cliente_nombre,cliente_apellido,cliente_DNI FROM EL_JAPONES_SANGRANDO.Clientes WHERE cliente_estado = 1 AND " +
                           "cliente_nombre LIKE '" + nombre + "%' AND " +
                           "cliente_apellido LIKE '" + apellido + "%' " +
                           BD.condicionDNI(dni);
            return BD.busqueda(query);
        }

        public static DataTable filtroClienteModificar(string nombre, string apellido, string dni)
        {
            String query = "SELECT cliente_nombre,cliente_apellido,cliente_DNI FROM EL_JAPONES_SANGRANDO.Clientes WHERE " +
                           "cliente_nombre LIKE '" + nombre + "%' AND " +
                           "cliente_apellido LIKE '" + apellido + "%' " +
                           BD.condicionDNI(dni);
            return BD.busqueda(query);
        }

        public static String condicionDNI(String dni)
        {
            return (dni == "") ? "" : "AND cliente_DNI like '" + dni + "%'";
        }

        public static void eliminarCliente(string x, DataGridView dge, DataGridView dgm)
        {
            if (BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Clientes SET cliente_estado = 0 WHERE cliente_DNI = '" + x + "'") > 0)
            {
                MessageBox.Show("cliente eliminado", "cliente eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BD.actualizarVistasClientes(dge, dgm);
            }
        }

        public static void actualizarVistasClientes(DataGridView dge, DataGridView dgm)
        {
            string query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes";
            dgm.DataSource = BD.busqueda(query);
            query = "select cliente_nombre,cliente_apellido,cliente_DNI from EL_JAPONES_SANGRANDO.Clientes where cliente_estado = 1";
            dge.DataSource = BD.busqueda(query);
        }

        public static bool crearCliente(String nombre, String apellido, String dni, String mail, String direccion, String fechanacimiento, String CP, String telefono)
        {
            return BD.ABM("INSERT INTO EL_JAPONES_SANGRANDO.Clientes(cliente_DNI,cliente_nombre,cliente_apellido,cliente_fecha_nacimiento,cliente_mail,cliente_direccion,cliente_codigo_postal, cliente_telefono)values('" + dni + "','" + nombre + "','" + apellido + "','" + fechanacimiento + "','" + mail + "','" + direccion + "','" + CP + "', '" + telefono + "')") > 0;
        }

        public static string cantidadDeClientesCon(string dni)
        {
            return BD.consultaDeUnSoloResultado("select count(*) from EL_JAPONES_SANGRANDO.Clientes where cliente_DNI = '" + dni + "'");
        }

        public static DataTable cliente(string dni)
        {
            return BD.busqueda("select * from EL_JAPONES_SANGRANDO.Clientes where cliente_DNI ='" + dni + "'");
        }

        public static bool crearEmpresa(string rubro, string nombre, string direccion, string cuit)
        {
            string subquery = "(SELECT rubro_id FROM EL_JAPONES_SANGRANDO.Rubros WHERE rubro_desc = '" + rubro + "')";
            return BD.insert("Empresas", "(empresa_rubro,empresa_cuit,empresa_nombre,empresa_direccion)values(" + subquery + ", '" + cuit + "', '" + nombre + "', '" + direccion + "')") != 0;
        }

        public static bool eliminarEmpresa(string x)
        {
            return BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Empresas SET empresa_estado = 0 WHERE empresa_cuit = '" + x + "'") > 0;
        }

        public static String condicionRubro(string rubro)
        {
            return (rubro == "") ? "" : "AND rubro_desc = '" + rubro + "'";
        }

        public static DataTable filtroEmpresasElim(string nombre, string cuit, string rubro)
        {
            String query = "SELECT empresa_nombre,rubro_desc,empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id WHERE " +
                         "empresa_estado = 1 AND " +
                         "empresa_nombre LIKE '" + nombre + "%' AND " +
                         "empresa_cuit LIKE '" + cuit + "%' " +
                         BD.condicionRubro(rubro);
            return BD.busqueda(query);
        }

        public static DataTable filtroEmpresasModif(string nombre, string cuit, string rubro)
        {
            String query = "SELECT empresa_nombre,rubro_desc,empresa_cuit FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id WHERE " +
                         "empresa_nombre LIKE '" + nombre + "%' AND " +
                         "empresa_cuit LIKE '" + cuit + "%' " +
                         BD.condicionRubro(rubro);
            return BD.busqueda(query);
        }

        public static List<string> rubros()
        {
            string query = "SELECT rubro_desc FROM EL_JAPONES_SANGRANDO.Rubros";
            return BD.listaDeUnCampo(query);
        }

        public static DataTable actualizarEmpresasElim()
        {
            string query = "SELECT empresa_nombre,rubro_desc,empresa_cuit,empresa_direccion FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id WHERE empresa_estado = 1 ORDER BY 1";
            return BD.busqueda(query);
        }

        public static DataTable actualizarEmpresasModif()
        {
            string query = "SELECT empresa_nombre,rubro_desc,empresa_cuit,empresa_direccion FROM EL_JAPONES_SANGRANDO.Empresas join EL_JAPONES_SANGRANDO.Rubros on empresa_rubro = rubro_id ORDER BY 1";
            return BD.busqueda(query);
        }

        public static DataTable empresa(string cuit)
        {
            return BD.busqueda("select * from EL_JAPONES_SANGRANDO.Empresas where empresa_cuit ='" + cuit + "'");
        }

        public static string nombreEmpresa(string empresa)
        {
            return BD.consultaDeUnSoloResultado("Select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_cuit = '" + empresa + "'");
        }

        public static bool modificarEmpresa(int estado, string nombre, string direccion, string cuit, string rubro)
        {
            string subquery = "(SELECT rubro_id FROM EL_JAPONES_SANGRANDO.Rubros WHERE rubro_desc = '" + rubro + "')";
            int query = BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Empresas SET " +
                    "empresa_nombre = '" + nombre +
                    "',empresa_direccion = '" + direccion +
                    "',empresa_rubro = " + subquery +
                    ",empresa_estado = " + estado +
                    " WHERE empresa_cuit = '" + cuit + "'");
            return query > 0;
        }

        public static bool tieneRoles(String username)
        {
            string x = BD.consultaDeUnSoloResultado("select count(*) from EL_JAPONES_SANGRANDO.Usuario_Rol where Usuario_Rol_usuario = '" + username + "'");
            return Int32.Parse(x) > 0;
        }

        public static List<string> empresas()
        {
            string query = "SELECT empresa_nombre FROM EL_JAPONES_SANGRANDO.Empresas";
            return BD.listaDeUnCampo(query);
        }

        public static List<string> empresasActivas()
        {
            return BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_estado = 1");
        }

        public static string estadoFactura(string factura)
        {
            return BD.consultaDeUnSoloResultado("Select factura_estado from EL_JAPONES_SANGRANDO.Facturas where factura_numero = '" + factura + "'");
        }

        public static DataTable filtroFacturasModif(string cliente, string numero, string empresa)
        {
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE " +
                         "factura_cliente LIKE '" + cliente + "%' AND " +
                         "factura_numero LIKE '" + numero + "%'" +
                         BD.condicionDeEmpresas(empresa);
            return BD.busqueda(query);
        }

        public static DataTable filtroFacturasElim(string cliente, string factura, string empresa)
        {
            String query = "SELECT  factura_numero,factura_empresa,factura_cliente from EL_JAPONES_SANGRANDO.Facturas WHERE factura_estado = 1 AND " +
                          "factura_cliente LIKE '" + cliente + "%' AND " +
                          "factura_numero LIKE '" + factura + "%'" +
                          BD.condicionDeEmpresas(empresa);
            return BD.busqueda(query);
        }

        public static String condicionDeEmpresas(string empresa)
        {
            return (empresa == "") ? "" : " AND factura_empresa =  (select top 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + empresa + "')";
        }

        public static bool eliminarFactura(string numeroDeFactura)
        {
            return BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 0 WHERE factura_numero = '" + numeroDeFactura + "'") > 0;
        }

        public static DataTable factura(string numeroDeFactura)
        {
            return BD.busqueda("select * from EL_JAPONES_SANGRANDO.Facturas where factura_numero ='" + numeroDeFactura + "'");
        }

        public static string facturaUnSoloResultado(string numeroDeFactura)
        {
            return BD.consultaDeUnSoloResultado("select * from EL_JAPONES_SANGRANDO.Facturas where factura_numero = " + numeroDeFactura + "");
        }

        public static bool facturaNoPagada(string numeroDeFactura)
        {
            return BD.consultaDeUnSoloResultado("select pago_Factura_factura from EL_JAPONES_SANGRANDO.Facturas join EL_JAPONES_SANGRANDO.Pago_Factura on (pago_Factura_factura = factura_numero) WHERE factura_numero = '" + numeroDeFactura + "'") == "";
        }

        public static void cargarFactura(String fechaVenc, String fechaAlta, string factura, string dni, string empresa, ListView.ListViewItemCollection lista)
        {
            double sum = 0;
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.Item_Factura (item_monto, item_cantidad, item_factura) VALUES ";
            foreach (ListViewItem eachItem in lista)
            {
                query += "(" + eachItem.SubItems[0].Text.Replace(',', '.') + "," + eachItem.SubItems[1].Text.Replace(',', '.') + ",'" + factura + "'),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);

            string empresa_cuit = BD.consultaDeUnSoloResultado("(select TOP 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + empresa + "')");

            string queryFactura = "INSERT INTO EL_JAPONES_SANGRANDO.Facturas (factura_numero,factura_empresa, factura_cliente, factura_fecha, factura_fecha_vencimiento, factura_total) values ("
                                    + factura + ",'"
                                    + empresa_cuit + "',"
                                    + dni + ",'"
                                    + fechaAlta + "','"
                                    + fechaVenc + "',"
                                    + sum.ToString().Replace(',', '.') + ")";

            if (BD.ABM(queryFactura) > 0)
            {
                if (BD.ABM(query) > 0)
                {
                    MessageBox.Show("Factura creada correctamente");
                }
                else
                {
                    BD.ABM("DELETE FROM EL_JAPONES_SANGRANDO.Facturas where factura_numero = '" + factura + "'");
                    MessageBox.Show("Error al generar los items");
                }
            }
            else
            {
                MessageBox.Show("Error al crear la factura, ya existe una factura con ese numero");
            }
        }

        public static DataTable facturasElim()
        {
            string query = "select DISTINCT factura_numero,(select empresa_nombre from EL_JAPONES_SANGRANDO.EMPRESAS where empresa_cuit = factura_empresa),factura_cliente from EL_JAPONES_SANGRANDO.Facturas where factura_estado = 1";
            return BD.busqueda(query);
        }

        public static DataTable facturasModif()
        {
            string query = "select DISTINCT factura_numero,(select empresa_nombre from EL_JAPONES_SANGRANDO.EMPRESAS where empresa_cuit = factura_empresa),factura_cliente from EL_JAPONES_SANGRANDO.Facturas";
            return BD.busqueda(query);
        }

        public static DataTable items(string numeroDeFactura)
        {
            return BD.busqueda("select * from EL_JAPONES_SANGRANDO.Item_Factura where item_factura ='" + numeroDeFactura + "'");
        }

        public static void modificarFactura(string factura, ListView.ListViewItemCollection lista, bool check, string empresa, string dni, string fechaAlta, string fechaVenc)
        {
            string queryEliminarfacturas = "Delete from EL_JAPONES_SANGRANDO.Item_Factura where item_factura = " + factura;
            double sum = 0;
            string query = "INSERT INTO EL_JAPONES_SANGRANDO.Item_Factura (item_monto, item_cantidad, item_factura) VALUES ";
            foreach (ListViewItem eachItem in lista)
            {
                query += "(" + eachItem.SubItems[0].Text.Replace(',', '.') + "," + eachItem.SubItems[1].Text.Replace(',', '.') + "," + factura + "),";
                sum += Double.Parse(eachItem.SubItems[0].Text) * Double.Parse(eachItem.SubItems[1].Text);
            }
            query = query.Substring(0, query.Length - 1);
            string empresa_cuit = BD.consultaDeUnSoloResultado("(select TOP 1 empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre = '" + empresa + "')");
            int x = check ? 1 : 0;

            string queryFactura = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = " + x + ", factura_Empresa = '" + empresa_cuit + "', factura_cliente = " + dni + ", factura_fecha = '" + fechaAlta + "', factura_fecha_vencimiento = '" + fechaVenc + "', factura_total =" + sum.ToString().Replace(',', '.') + " where factura_numero ="
                                    + factura;



            List<String> listaDeStrings = new List<string>();
            listaDeStrings.Add(queryFactura);
            listaDeStrings.Add(queryEliminarfacturas);
            listaDeStrings.Add(query);
            if (BD.correrStoreProcedure(listaDeStrings) > 0)
            {
                MessageBox.Show("Se modifico correctamente");

            }
            else
            {
                MessageBox.Show("No se pudo modificar la factura, revise los datos ingresados");
            }

        }

        public static bool modificarSucursal(bool habilitado, string nombre, string direccion, string nombreViejo)
        {
            return BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Sucursales SET sucursal_nombre = '" + nombre + "',sucursal_direccion = '" + direccion + "',sucursal_estado = '" + habilitado + "' WHERE sucursal_nombre = '" + nombreViejo + "'") > 0;
        }

        public static bool eliminarSucursal(string sucursalNombre)
        {
            string update = "UPDATE EL_JAPONES_SANGRANDO.Sucursales SET sucursal_estado = 0 WHERE sucursal_nombre ='" + sucursalNombre + "'";
            string idSucursal = BD.consultaDeUnSoloResultado("select sucursal_codigo_postal from EL_JAPONES_SANGRANDO.Sucursales where sucursal_nombre ='" + sucursalNombre + "'");
            List<String> lista = new List<String>();
            lista.Add(update);
            return BD.correrStoreProcedure(lista) > 0;
        }

        public static DataTable sucursalesActivas()
        {
            return BD.busqueda("select sucursal_nombre,sucursal_codigo_postal,sucursal_direccion from EL_JAPONES_SANGRANDO.Sucursales where sucursal_estado = 1");
        }

        public static DataTable sucursales()
        {
            return BD.busqueda("select sucursal_nombre,sucursal_codigo_postal,sucursal_direccion from EL_JAPONES_SANGRANDO.Sucursales");
        }

        public static bool crearSucursal(string codigo_postal, string nombre, string direccion)
        {
            return BD.ABM("INSERT INTO [EL_JAPONES_SANGRANDO].[Sucursales](sucursal_codigo_postal,sucursal_direccion,sucursal_nombre)values(" + codigo_postal + ",'" + direccion + "','" + nombre + "')") != 0;
        }

        public static List<String> sucursalesDeUsuario()
        {
            string query = "SELECT sucursal_nombre FROM EL_JAPONES_SANGRANDO.Sucursales join EL_JAPONES_SANGRANDO.Usuario_Sucursal ON (usuario_Sucursal_sucursal = sucursal_codigo_postal) WHERE sucursal_estado = 1 AND usuario_Sucursal_usuario = '" + BD.getUsuario() + "'";
            return BD.listaDeUnCampo(query);
        }
    }
}
