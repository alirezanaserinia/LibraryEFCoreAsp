using BehKhaan.Domain.Entities;
using BehKhaan.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class Book_ShelfRepository : IBook_ShelfRepository
    {
        public void Edit(Book_Shelf entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book_Shelf> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book_Shelf GetById(string bookId, string shelfId)
        {
            throw new NotImplementedException();
        }

        public void Insert(Book_Shelf entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(string bookId, string shelfId)
        {
            throw new NotImplementedException();
        }
    }
}
