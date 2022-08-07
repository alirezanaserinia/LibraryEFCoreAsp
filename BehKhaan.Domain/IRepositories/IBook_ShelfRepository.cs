using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.IRepositories
{
    public interface IBook_ShelfRepository
    {
        public IEnumerable<Book_Shelf> GetAll();
        public Book_Shelf GetByBookIdAndShelfId(string bookId, string shelfId);
        public IEnumerable<Book_Shelf> GetBook_ShelfsByShelfId(string shelfId);
        public IEnumerable<Book_Shelf> GetBook_ShelfsByBookId(string bookId);
        public void Insert(Book_Shelf entity);
        public void Edit(Book_Shelf entity);
        public void Remove(string bookId, string shelfId);
    }
}
