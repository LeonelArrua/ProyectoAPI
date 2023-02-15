using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ProyectoAPI.Models;


namespace ProyectoAPI.Handlers
{
    internal static class UserHandler
    {
        public static string connectionString = "Data Source=DESKTOP-KTPC59F\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static User GetUserFromDB(int id)
        {

            User auxuser = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Usuario WHERE id='{id}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    auxuser = new User(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                }
            }
            return auxuser;
        }

        internal static List<User> GetUsersFromDB()
        {
            List<User> auxuserlist = new List<User>();
   
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Usuario ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        User aux = new User(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                        auxuserlist.Add(aux);
                    }
        
                }
            }
            return auxuserlist;
        }



        public static User LogginUser(string user, string password)
        {

            User auxuser = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Usuario WHERE NombreUsuario='{user}' AND Contraseña='{password}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    auxuser = new User(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
                }
            }
            return auxuser;
        }
        public static void ModifyUser(User usr) 
         {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = @"UPDATE Usuario SET Nombre = @_firstName, Apellido = @_lastName, NombreUsuario = @_userName, Contraseña = @_password, Mail = @_email WHERE Id= @_id";

                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection)) 
                { 
                command.Parameters.Add(new SqlParameter("_id", SqlDbType.BigInt) {Value = usr.Id});
                command.Parameters.Add(new SqlParameter("_firstName", SqlDbType.VarChar) { Value = usr.FirstName });
                command.Parameters.Add(new SqlParameter("_lastName", SqlDbType.VarChar) { Value = usr.LastName });
                command.Parameters.Add(new SqlParameter("_userName", SqlDbType.VarChar) { Value = usr.UserName});
                command.Parameters.Add(new SqlParameter("_password", SqlDbType.VarChar) { Value = usr.Password});
                command.Parameters.Add(new SqlParameter("_email", SqlDbType.VarChar) { Value = usr.Email });
                command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

    }
}
//UPDATE [SistemaGestion].[dbo].[Usuario] SET [Contraseña] = 'MINUEVACONTRASENIA' WHERE[Nombre] = 'Ernesto'
