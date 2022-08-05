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
    public class Book_ShelfRepository : IBook_ShelfRepository
    {
        private readonly AppDbContext _context;
        public Book_ShelfRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Edit(Book_Shelf entity)
        {
            EntityEntry entityEntry = _context.Entry<Book_Shelf>(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Book_Shelf> GetAll() => _context.Books_Shelfs.ToList();

        public Book_Shelf GetById(string bookId, string shelfId) => _context.Books_Shelfs.FirstOrDefault(bs => bs.BookId == bookId && bs.ShelfId==shelfId);

        public void Insert(Book_Shelf entity)
        {
            _context.Books_Shelfs.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(string bookId, string shelfId)
        {
            var entity = _context.Books_Shelfs.FirstOrDefault(bs => bs.BookId == bookId && bs.ShelfId == shelfId);
            EntityEntry entityEntry = _context.Entry<Book_Shelf>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
