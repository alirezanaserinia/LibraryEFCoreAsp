using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }

        //Relationships
        public List<Book_Shelf> Books_Shelfs { get; set; }
    }
}
