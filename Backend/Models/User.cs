using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TokensAvailable { get; set; }
        public List<int> BooksBorrowed { get; set; } = new List<int>();
        public List<int> BooksLent { get; set; } = new List<int>();
        //public List<int> BooksAdded { get; set; } = new List<int>();


    }
}
