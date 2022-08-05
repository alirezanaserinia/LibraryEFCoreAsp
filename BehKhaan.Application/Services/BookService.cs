using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using BehKhaan.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public void InsertBook(InsertBookModel bookModel)
        {
            Book book = new Book()
            {
                Id = Guid.NewGuid().ToString(),
                ISBN = bookModel.ISBN,
                Name = bookModel.Name,
                Description = bookModel.Description,
                ImageURL = bookModel.ImageURL,
                Price = bookModel.Price,
                Rate = bookModel.Rate
            };

            _bookRepository.Insert(book);
        }

    }
}
