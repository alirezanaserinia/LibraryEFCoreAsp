using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Models
{
    public class ShelfModel
    {
        public string Name { get; set; }
        
        public string UserId { get; set; }
    }

    public class ShelfWithBooksModel
    {
        public string Name { get; set; }

        public string UserId { get; set; }
        public List<string>? BookNames { get; set; }
    }
}
