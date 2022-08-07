using BehKhaan.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Interfaces
{
    public interface IModelValidator
    {
        public ValidationModel CheckBook_ShelfModelValidation(Book_ShelfModel book_ShelfModel);
    }
}
