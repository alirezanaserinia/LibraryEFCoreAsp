using BehKhaan.Domain.Entities;
using BehKhaan.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        public void Edit(Book entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
