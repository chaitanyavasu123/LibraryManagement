using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Borrowing
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int LentBy { get; set; } // User who lent the book (OwnerId)
        public int BorrowerId { get; set; } // User who borrowed the book
        public DateTime BorrowingTime { get; set; }
    }
}
