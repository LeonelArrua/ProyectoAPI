using ProyectoAPI.Models;
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
      
        public static List<Sale> getSalesFromDB(long id)
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
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

        public static long insertSale(Sale sale) {
            using (SqlConnection connect = new SqlConnection(Program.connectionstring))
            {

                SqlCommand command = new SqlCommand("INSERT INTO Venta(Comentarios,IdUsuario)" + "VALUES (@_comments,@_userId); SELECT @@IDENTITY", connect);
                command.Parameters.Add(new SqlParameter("_comments", System.Data.SqlDbType.VarChar) { Value = sale.Comments });
                command.Parameters.Add(new SqlParameter("_userId", System.Data.SqlDbType.VarChar) { Value = sale.UserId});
                connect.Open();
                return Convert.ToInt64(command.ExecuteScalar());
            }
        }
        public static void insertSales(long UserId, List<Product> soldproducts) {

            using (SqlConnection connect = new SqlConnection(Program.connectionstring)) {
                Sale sale = new Sale();
                sale.UserId = UserId;
                sale.Comments = "";
                long SaleId = insertSale(sale);
                foreach (Product product in soldproducts) { 
                        SoldProduct newsoldproduct = new SoldProduct();
                        newsoldproduct.ProductId = product.Id;
                        newsoldproduct.SalelId = SaleId;
                        newsoldproduct.Stock = product.Stock;
                        SoldProductHandler.insertSoldProduct(newsoldproduct);
                        ProductHandler.UpdateProductStock(product.Id, product.Stock);
                }
            }
        }
    }
}
