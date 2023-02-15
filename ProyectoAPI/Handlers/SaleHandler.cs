using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPI.Handlers
{
    internal static class SaleHandler
    {
        public static string connectionString = "Data Source=DESKTOP-KTPC59F\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Sale> getSalesFromDB(long id)
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Venta WHERE Venta.IdUsuario ='{id}'", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Sale aux = new Sale(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2));
                        sales.Add(aux);
                    }
                }
            }
            return sales;
        }
    }
}
