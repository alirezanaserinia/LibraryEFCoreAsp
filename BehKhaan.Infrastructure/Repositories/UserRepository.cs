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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Edit(User entity)
        {
            EntityEntry entityEntry = _context.Entry<User>(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetById(string id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public bool isUserNameExists(string userName)
        {
            var userNames = _context.Users.Select(u => u.UserName)
                .Any();
            if (userNames)
            {
                return _context.Users.Select(u => u.UserName).Contains(userName);
            }
            else
            {
                return false;
            }
        }

        public void Remove(string id)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == id);
            EntityEntry entityEntry = _context.Entry<User>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

    }
}
