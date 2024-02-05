using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Return
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReturningBy { get; set; } // User who is returning the book (UserId)
        public int ReturnTo { get; set; } // User to whom the book is returned (OwnerId)
        public DateTime ReturningTime { get; set; }
    }
}
