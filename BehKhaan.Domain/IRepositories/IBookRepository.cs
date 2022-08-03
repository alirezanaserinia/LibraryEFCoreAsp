using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.IRepositories
{
    public interface IBookRepository
    {
        public IEnumerable<Book> GetAll();
        public Book GetById(string id);
        public void Insert(Book entity);
        public void Edit(Book entity);
        public void Remove(string id);
    }
}
