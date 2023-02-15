using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPI
{
    public class SoldProduct
    {
            private long _id;
            private long _salelId;
            private long _productId;
            private int _stock;

        public SoldProduct()
        {
        }
        public SoldProduct(long id, long salelId, long productId, int stock)
        {
            Id = id;
            SalelId = salelId;
            ProductId = productId;
            Stock = stock;
        }
        public long Id { get => _id; set => _id = value; }
        public long SalelId { get => _salelId; set => _salelId = value; }
        public long ProductId { get => _productId; set => _productId = value; }
        public int Stock { get => _stock; set => _stock = value; }
    }
}
