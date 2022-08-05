using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Services
{
    public interface IBookService
    {
        public IEnumerable<Book> GetBooks();
        public void InsertBook(InsertBookModel bookModel);
    }
}
