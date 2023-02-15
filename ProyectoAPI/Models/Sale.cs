using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAPI
{
    public class Sale
    {
        private long _id;
        private string _comments;
        private long _userId;

        public Sale()
        {
        }
        public Sale(long id, string comments, long userId)
        {
            Id = id;
            Comments = comments;
            UserId = userId;
        }

        public long Id { get => _id; set => _id = value; }
        public string Comments { get => _comments; set => _comments = value; }
        public long UserId { get => _userId; set => _userId = value; }
    }
}
