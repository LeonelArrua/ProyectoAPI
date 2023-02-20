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
       
        public static List<Product> getSoldProductFromDB(long id)
        {

            List<Product> soldproducts = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
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
        public static List<Product> getSoldProductFromDB()
        {

            List<Product> soldproducts = new List<Product>();

            using (SqlConnection connection = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand($"SELECT * FROM Producto INNER JOIN ProductoVendido ON Producto.Id = ProductoVendido.IdProducto", connection);
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
            using (SqlConnection connect = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand("DELETE FROM ProductoVendido WHERE IdProducto =@idprod", connect);
                command.Parameters.Add(new SqlParameter("idprod", System.Data.SqlDbType.BigInt) { Value = id });
                connect.Open();
                return command.ExecuteNonQuery();
            }
        }
        public static int insertSoldProduct(SoldProduct soldproduct) {
            using (SqlConnection connect = new SqlConnection(Program.connectionstring))
            {
                SqlCommand command = new SqlCommand("INSERT INTO ProductoVendido(Stock,IdProducto,IdVenta)" + "VALUES (@_stock,@_idproduct,@_idsale)", connect);

                command.Parameters.Add(new SqlParameter("_stock", System.Data.SqlDbType.Int) { Value = soldproduct.Stock });
                command.Parameters.Add(new SqlParameter("_idproduct", System.Data.SqlDbType.BigInt) { Value = soldproduct.ProductId });
                command.Parameters.Add(new SqlParameter("_idsale", System.Data.SqlDbType.BigInt) { Value = soldproduct.SalelId });

                connect.Open();
                return command.ExecuteNonQuery();
            }

        }


    }
}
