using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPI.Models
{
    public class Product
    {
        private long _id;
        private string _description;
        private decimal _price;
        private decimal _salePrice;
        private int _stock;
        private long _userId;

        public Product()
        {
        }

        public Product(long id, string description, decimal price, decimal salePrice, int stock, long userId)
        {
            Id = id;
            Description = description;
            Price = price;
            SalePrice = salePrice;
            Stock = stock;
            UserId = userId;
        }

        public long Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Price { get => _price; set => _price = value; }
        public decimal SalePrice { get => _salePrice; set => _salePrice = value; }
        public int Stock { get => _stock; set => _stock = value; }
        public long UserId { get => _userId; set => _userId = value; }
    }
}
