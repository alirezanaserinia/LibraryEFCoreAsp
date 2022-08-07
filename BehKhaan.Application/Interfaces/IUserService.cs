using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(string id);
        public void InsertUser(UserModel bookModel);
        public void EditUser(string id, UserModel bookModel);
        public void RemoveUser(string id);
        public UserWithShelfsModel GetUserWithShelfsByUserId(string userId);
    }
}
