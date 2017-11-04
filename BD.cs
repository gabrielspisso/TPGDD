﻿using System;
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
using System.Data;
using PagoAgilFrba.Sucursal;
namespace PagoAgilFrba
{
    public class BD
    {
        private static String connectionString = @"Data Source=localhost\SQLSERVER2012;Initial Catalog=GD2C2017;User ID=gd;Password=gd2017";

        public static SqlConnection getConnection()
        {
            return new SqlConnection(connectionString);
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
        public static int correrStoreProcedure(List<String> listaDeValores)
        {
            SqlConnection connection = getConnection();
            connection.Open();
           
          
            String y = "BEGIN TRANSACTION;";
            listaDeValores.ForEach(delegate(String name)
            {
                y += name +";";
            });
            y+= "COMMIT;";
             SqlCommand command = new SqlCommand(y);
            command.Connection = connection;
            
            int x;
            try
            {
                x = command.ExecuteNonQuery();
           
            }
            catch (Exception ex)
            {
                x = 0;
            }
            connection.Close();
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
    }
}
