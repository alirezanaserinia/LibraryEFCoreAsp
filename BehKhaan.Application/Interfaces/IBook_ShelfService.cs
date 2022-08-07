using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Interfaces
{
    public interface IBook_ShelfService
    {
        public void AddBookToShelf(Book_ShelfModel book_ShelfModel);
        public Book_Shelf GetByBookIdAndShelfId(string bookId, string shelfId);
        public BookWithShelfsModel GetBookWithShelfsByBookId(string bookId);
        public ShelfWithBooksModel GetShelfWithBooksByShelfId(string shelfId);
        
        //public void Change
    }
}
