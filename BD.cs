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
            SqlCommand loginCommand = new SqlCommand("SELECT usr_name, usr_pass FROM EL_JAPONES_SANGRANDO.Usuarios WHERE usr_name=@username");
            loginCommand.Parameters.AddWithValue("username", username);
            loginCommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = loginCommand.ExecuteReader();
            String nombreUsuario = null;
            byte[] dbPassword = null;
            while (reader.Read())
            {
                nombreUsuario = reader["usr_name"].ToString();
                dbPassword = reader.GetSqlBytes(reader.GetOrdinal("usr_pass")).Buffer;
            }
            reader.Close();
            connection.Close();
            if (nombreUsuario != null)
            {
                if (sha256_hash(password).SequenceEqual(dbPassword))
                    return true;
            }

            

            return false;

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

    }
}
