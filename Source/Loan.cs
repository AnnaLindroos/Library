using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Loan
    {
        public Book Book { get; set; }

        public DateTime DueDate { get; set; }

        public Loan (Book book, DateTime dueDate)
        {
            Book = book;
            DueDate = dueDate;
        }
    }
}
