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
    public class ShelfRepository : IShelfRepository
    {
        private readonly AppDbContext _context;
        public ShelfRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Edit(Shelf entity)
        {
            EntityEntry entityEntry = _context.Entry<Shelf>(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    

        public IEnumerable<Shelf> GetAll() => _context.Shelfs.ToList();

        public Shelf GetById(string id) => _context.Shelfs.FirstOrDefault(s => s.Id == id);

        public void Insert(Shelf entity)
        {
            _context.Shelfs.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(string id)
        {
            var entity = _context.Shelfs.FirstOrDefault(s => s.Id == id);
            EntityEntry entityEntry = _context.Entry<Shelf>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
