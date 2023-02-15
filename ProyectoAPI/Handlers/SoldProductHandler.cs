using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAPI.Models;

namespace ProyectoAPI.Handlers
{
    internal static class SoldProductHandler
    {
        public static string connectionString = "Data Source=DESKTOP-KTPC59F\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Product> getSoldProductFromDB(long id)
        {

            List<Product> soldproducts = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Producto INNER JOIN ProductoVendido ON Producto.Id = ProductoVendido.IdProducto WHERE Producto.idUsuario='{id}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Product aux = new Product(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));
                        soldproducts.Add(aux);
                    }
                }

            }
            return soldproducts;
        }

        public static int deleteSoldProduct(long id)
        {

            using (SqlConnection connect = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("DELETE FROM ProductoVendido INNER JOIN Producto ON ProductoVendido.IdProducto = Producto.Id WHERE Id=@idprod", connect);
                command.Parameters.Add(new SqlParameter("idprod", System.Data.SqlDbType.BigInt) { Value = id });
                connect.Open();
                return command.ExecuteNonQuery();
            }





        }









    }
}
