using BehKhaan.Application.Interfaces;
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
        private readonly IBook_ShelfRepository _bookShelfRepository;

        public BookService(IBookRepository bookRepository, IBook_ShelfRepository bookShelfRepository)
        {
            _bookRepository = bookRepository;
            _bookShelfRepository = bookShelfRepository;
        }

        public void EditBook(string id ,BookModel bookModel)
        {
            var book = _bookRepository.GetById(id);
            if (book != null)
            {
                book.ISBN = bookModel.ISBN;
                book.Name = bookModel.Name;
                book.Description = bookModel.Description;
                book.ImageURL = bookModel.ImageURL;
                book.Price = bookModel.Price;
                book.Rate = bookModel.Rate;

                _bookRepository.Edit(book);
            }
        }

        public Book GetBookById(string id)
        {
            return _bookRepository.GetById(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }

        public IEnumerable<BookWithNumOfReadersModel> GetOrderedListOfBooksBasedOnUserReception()
        {
            List<BookWithNumOfReadersModel> booksList = new List<BookWithNumOfReadersModel>();
            int NumOfReaders = 0;
            var books = _bookRepository.GetAll();
            foreach (var book in books)
            {
                var book_Shelfs = _bookShelfRepository.GetBook_ShelfsByBookId(book.Id);
                NumOfReaders = 0;
                foreach (var book_Shelf in book_Shelfs)
                {
                    if (book_Shelf.StudyState == 2)
                    {
                        NumOfReaders++;
                    }
                }
                booksList.Add(
                    new BookWithNumOfReadersModel()
                    {
                        Id = book.Id,
                        Name = book.Name,
                        NumOfReaders = NumOfReaders
                    });
            }
            return booksList.OrderByDescending(b => b.NumOfReaders).ToList();
        }

        public void InsertBook(BookModel bookModel)
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

        public void RemoveBook(string id)
        {
            _bookRepository.Remove(id);
        }

    }
}
