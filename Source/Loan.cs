using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class Loan
    {
        public string TitleOfBook { get; set; }

        public DateTime LengthOfLoan { get; set; }
        
        public Loan (string titleOfBook, DateTime lengthOfLoan)
        {
            TitleOfBook = titleOfBook;
            LengthOfLoan = lengthOfLoan;
        }
    }
}
