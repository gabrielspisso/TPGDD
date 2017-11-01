using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using System.Data;
using PagoAgilFrba.Clases;
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
            SqlCommand loginCommand = new SqlCommand("SELECT usr_name, usr_pass,usr_cantidadDeIntentos FROM EL_JAPONES_SANGRANDO.Usuarios WHERE usr_name=@username");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombreUsuario = null;
            byte[] dbPassword = null;
            int intentosFallidos = 0;
            while (reader.Read())
            {
                nombreUsuario = reader["usr_name"].ToString();
                dbPassword = reader.GetSqlBytes(reader.GetOrdinal("usr_pass")).Buffer;
                intentosFallidos = reader.GetInt32(reader.GetOrdinal("usr_cantidadDeIntentos"));
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
                    MessageBox.Show("todo bien", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            SqlCommand loginCommand = new SqlCommand("SELECT usr_cantidadDeIntentos FROM EL_JAPONES_SANGRANDO.Usuarios WHERE usr_name=@username");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            string cantidadDeVeces = "0";
            while (reader.Read())
            {
                cantidadDeVeces = reader["usr_name"].ToString();
            }
            reader.Close();
            connection.Close();

            return Int32.Parse(cantidadDeVeces);
        }

        public static List<String> roles(string username)
        {
            List<String> listaRoles = new List<string>();
            SqlConnection connection = getConnection();
            SqlCommand loginCommand = new SqlCommand("SELECT rol_nombre FROM EL_JAPONES_SANGRANDO.Roles JOIN EL_JAPONES_SANGRANDO.RolUsuario on rol_nombre=rolusr_rol WHERE rolusr_usr=@username and rol_estado=1");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombreUsuario = null;
            byte[] dbPassword = null;
            while (reader.Read())
            {
                listaRoles.Add(reader["rol_nombre"].ToString());
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
            SqlCommand query = new SqlCommand("UPDATE EL_JAPONES_SANGRANDO.Usuarios SET usr_cantidadDeIntentos = @cantidad WHERE usr_name = @usr_name");
            query.Parameters.AddWithValue("usr_name",username);

            query.Parameters.AddWithValue("cantidad", numeroDeIntentos);
            query.Connection = connection;
            query.ExecuteNonQuery();
            connection.Close();
        }

        public static void modificarEstadoUsuario(string username, int estado)
        {

            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand query = new SqlCommand("UPDATE EL_JAPONES_SANGRANDO.Usuarios SET usr_estado = @estado WHERE usr_name = @usr_name");
            query.Parameters.AddWithValue("usr_name", username);
            query.Parameters.AddWithValue("estado", estado);
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
            SqlCommand query = new SqlCommand("INSERT INTO EL_JAPONES_SANGRANDO.[RolFuncionalidades](rolf_rol,rolf_func)values(@rol,@funcionalidad)");
            query.Parameters.AddWithValue("rol", rol);
            query.Parameters.AddWithValue("funcionalidad", funcionalidadId);

            query.Connection = connection;
            query.ExecuteNonQuery();
            connection.Close();
        }

        internal static void actualizarFuncionalidadesPara(Rol rol, List<Funcionalidad> list)
        {
            SqlConnection connection = getConnection();
            connection.Open();
            SqlCommand borrarRolesViejos = new SqlCommand("DELETE FROM LA_VIDA_ES_UN_FOR_Y_UN_IF.RolesXFuncionalidades WHERE rolXFuncionalidad_rol = @rol");
            borrarRolesViejos.Parameters.AddWithValue("rol", rol.id);
            borrarRolesViejos.Connection = connection;
            borrarRolesViejos.ExecuteNonQuery();
            String query = "INSERT INTO LA_VIDA_ES_UN_FOR_Y_UN_IF.RolesXFuncionalidades VALUES ";
            List<Funcionalidad> filteredList = list.FindAll(func => func.activado);
            if (filteredList.Count >= 0)
            {
                var parameters = filteredList.Select(func => "(" + rol.id + "," + func.id + ")").ToArray();
                query += string.Join(",", parameters);
                SqlCommand insertarRolesNuevos = new SqlCommand(query);
                insertarRolesNuevos.Connection = connection;
                insertarRolesNuevos.ExecuteNonQuery();
            }
            connection.Close();
        }
    }
}
