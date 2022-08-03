using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        //Relationships
        public List<Shelf> Shelfs { get; set; }
    }
}
