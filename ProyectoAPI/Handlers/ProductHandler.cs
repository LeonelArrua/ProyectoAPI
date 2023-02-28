using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProyectoAPI.Models;

namespace ProyectoAPI.Handlers
{
    internal static class ProductHandler
    {
        

        internal static List<Product> getProductsFromDB(long id)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Producto WHERE idUsuario='{id}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Product aux;
                        Product aux = new Product(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));
                        products.Add(aux);
                    }
                }

            }
            return products;
        }
        internal static Product getProductFromDB(long id)
        {
            Product products = new Product();

            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Producto WHERE Id='{id}' ", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    products = new Product(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));
                }

            }
            return products;
        }



        internal static List<Product> getProductsFromDB()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand($"SELECT * From Producto", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //Product aux;
                        Product aux = new Product(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));
                        products.Add(aux);
                    }
                }

            }
            return products;
        }

        public static int insertProduct(Product product) {

            using (SqlConnection connect = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand("INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario)" + "VALUES (@_description,@_price,@_salePrice,@_stock,@_userId)", connect);

                    command.Parameters.Add(new SqlParameter("_description", System.Data.SqlDbType.VarChar) { Value = product.Description });
                    command.Parameters.Add(new SqlParameter("_price", System.Data.SqlDbType.Decimal) { Value = product.Price });
                    command.Parameters.Add(new SqlParameter("_salePrice", System.Data.SqlDbType.Decimal) { Value = product.SalePrice });
                    command.Parameters.Add(new SqlParameter("_stock", System.Data.SqlDbType.Int) { Value = product.Stock });
                    command.Parameters.Add(new SqlParameter("_userId", System.Data.SqlDbType.BigInt) { Value = product.UserId });

                connect.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int updateProduct(Product product) {
            using (SqlConnection connect = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand("UPDATE Producto SET Descripciones = @_description, Costo = @_price, PrecioVenta = @_salePrice, Stock = @_stock, IdUsuario = @_userId WHERE Id= @_id", connect);

                command.Parameters.Add(new SqlParameter("_description", System.Data.SqlDbType.VarChar) { Value = product.Description });
                command.Parameters.Add(new SqlParameter("_price", System.Data.SqlDbType.Decimal) { Value = product.Price });
                command.Parameters.Add(new SqlParameter("_salePrice", System.Data.SqlDbType.Decimal) { Value = product.SalePrice });
                command.Parameters.Add(new SqlParameter("_stock", System.Data.SqlDbType.Int) { Value = product.Stock });
                command.Parameters.Add(new SqlParameter("_userId", System.Data.SqlDbType.BigInt) { Value = product.UserId });
                command.Parameters.Add(new SqlParameter("_id", System.Data.SqlDbType.BigInt) { Value = product.Id });

                connect.Open();
                return command.ExecuteNonQuery();
            }
        }

        public static int deleteProduct(long id) 
        {

            using (SqlConnection connect = new SqlConnection(Program.connectionstring)) {
                SqlCommand command = new SqlCommand("DELETE FROM Producto WHERE Id=@id", connect);
                command.Parameters.Add(new SqlParameter("id", System.Data.SqlDbType.BigInt){ Value = id});
                connect.Open();
                return command.ExecuteNonQuery();
            }

        }
        public static int UpdateProductStock(long id, int soldamount)
        {
            Product product = getProductFromDB(id);
            product.Stock -= soldamount;
            return updateProduct(product);
        }
    }
}

