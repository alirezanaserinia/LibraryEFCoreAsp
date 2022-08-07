using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.Entities
{
    public class Shelf
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // User
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
