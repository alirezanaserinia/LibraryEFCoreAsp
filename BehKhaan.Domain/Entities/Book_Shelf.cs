using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.Entities
{
    public class Book_Shelf
    {
        public int StudyState { get; set; }
        public DateTime PuttingTime { get; set; }
        
        // Book
        public string BookId { get; set; }
        public Book Book { get; set; }

        // Shelf
        public string ShelfId { get; set; }
        public Shelf Shelf { get; set; }
    }
}
