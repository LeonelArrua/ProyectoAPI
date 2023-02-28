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
            private int _stock;
            private long _salelId;
            private long _productId;
            

        public SoldProduct()
        {
        }
        public SoldProduct(long id, int stock, long salelId, long productId)
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
