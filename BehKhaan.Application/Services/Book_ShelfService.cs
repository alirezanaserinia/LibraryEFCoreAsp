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
    public class Book_ShelfService : IBook_ShelfService
    {
        private readonly IBook_ShelfRepository _book_ShelfRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IShelfRepository _shelfRepository;

        public Book_ShelfService(IBook_ShelfRepository book_ShelfRepository, IBookRepository bookRepository, 
            IShelfRepository shelfRepository)
        {
            _book_ShelfRepository = book_ShelfRepository;
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;
        }

        public void AddBookToShelf(Book_ShelfModel book_ShelfModel)
        {
            Book_Shelf book_Shelf = new Book_Shelf()
            {
                BookId = book_ShelfModel.BookId,
                ShelfId = book_ShelfModel.ShelfId,
                StudyState = book_ShelfModel.StudyState,
                PuttingTime = DateTime.Now
            };
            _book_ShelfRepository.Insert(book_Shelf);
        }

        public void ChangeBookStudyState(Book_ShelfModel book_shelfModel)
        {
            var book_Shelf = _book_ShelfRepository.GetByBookIdAndShelfId(book_shelfModel.BookId, book_shelfModel.ShelfId);
            if (book_Shelf != null)
            {
                book_Shelf.StudyState = book_shelfModel.StudyState;
                _book_ShelfRepository.Edit(book_Shelf);
            }
        }

        public BookWithShelfsModel GetBookWithShelfsByBookId(string bookId)
        {
            var book_Shelfs = _book_ShelfRepository.GetBook_ShelfsByBookId(bookId);

            var book = book_Shelfs.FirstOrDefault()?.Book;

            if (book == null)
            {
                return null;
            }

            var bookWithShelfs = new BookWithShelfsModel()
            {
                ISBN = book.ISBN,
                Name = book.Name,
                Description = book.Description,
                ImageURL = book.ImageURL,
                Price = book.Price,
                Rate = book.Rate,
                ShelfNames = book_Shelfs.Select(bs => bs.Shelf.Name).ToList()
            };

            return bookWithShelfs;
        }

        public Book_Shelf GetByBookIdAndShelfId(string bookId, string shelfId)
        {
            return _book_ShelfRepository.GetByBookIdAndShelfId(bookId, shelfId);
        }

        public ShelfWithBooksModel GetShelfWithBooksByShelfId(string shelfId)
        {
            var book_Shelfs = _book_ShelfRepository.GetBook_ShelfsByShelfId(shelfId);

            var shelf = book_Shelfs.FirstOrDefault()?.Shelf;

            if (shelf == null)
            {
                return null;
            }

            var shelfWithBooks = new ShelfWithBooksModel()
            {
                Name = shelf.Name,
                UserId = shelf.UserId,
                BookNames = book_Shelfs.Select(bs => bs.Book.Name).ToList()
            };

            return shelfWithBooks;
        }

        public void RemoveBookFromShelf(string bookId, string shelfId)
        {
            _book_ShelfRepository.Remove(bookId, shelfId);
        }
    }
}
