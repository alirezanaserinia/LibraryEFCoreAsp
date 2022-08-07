using BehKhaan.Application.Models;
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
        public BookWithShelfsModel GetBookWithShelfsByBookId(string bookId);
        public ShelfWithBooksModel GetShelfWithBooksByShelfId(string shelfId);

    }
}
