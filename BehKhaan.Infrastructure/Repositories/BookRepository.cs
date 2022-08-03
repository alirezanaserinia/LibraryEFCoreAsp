using BehKhaan.Domain.Entities;
using BehKhaan.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Edit(Book entity)
        {
            EntityEntry entityEntry = _context.Entry<Book>(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll() => _context.Books.ToList();

        public Book GetById(string id) => _context.Books.FirstOrDefault(b => b.Id == id);

        public void Insert(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(string id)
        {
            var entity = _context.Books.FirstOrDefault(b => b.Id == id);
            EntityEntry entityEntry = _context.Entry<Book>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
