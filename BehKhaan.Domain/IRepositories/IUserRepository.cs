using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.IRepositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetById(string id);
        public void Insert(User entity);
        public void Edit(User entity);
        public void Remove(string id);
    }
}
