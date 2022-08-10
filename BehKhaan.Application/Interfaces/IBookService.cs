using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Interfaces
{
    public interface IBookService
    {
        public IEnumerable<Book> GetBooks();
        public Book GetBookById(string id);
        public void InsertBook(BookModel bookModel);
        public void EditBook(string id ,BookModel bookModel);
        public void RemoveBook(string id);
        public IEnumerable<BookWithNumOfReadersModel> GetOrderedListOfBooksBasedOnUserReception();
    }
}
