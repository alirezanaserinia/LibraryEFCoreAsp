using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
    }

    public class UserWithShelfsModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<string>? ShelfNames { get; set; }
    }
}
