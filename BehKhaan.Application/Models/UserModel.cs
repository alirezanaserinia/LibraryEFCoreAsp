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

    public class UserWithCountOfBooks
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int CountOfBooks { get; set; }
    }

    public class UserWithCountOfReadBooks
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int CountOfReadBooks { get; set; }
    }

    public class UserStudyState
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int CountOfReadBooks { get; set; }
        public int CountOfReadingBooks { get; set; }
        public int CountOfFutureStudyBooks { get; set; }
    }
}
