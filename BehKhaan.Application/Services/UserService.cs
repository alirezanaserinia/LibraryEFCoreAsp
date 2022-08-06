using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using BehKhaan.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void EditUser(string id, UserModel userModel)
        {
            var user = _userRepository.GetById(id);
            if (user != null)
            {
                user.UserName = userModel.UserName;
                user.FullName = userModel.FullName;

                _userRepository.Edit(user);
            }
        }

        public User GetUserById(string id)
        {
            return _userRepository.GetById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void InsertUser(UserModel bookModel)
        {
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = bookModel.UserName,
                FullName = bookModel.FullName
            };
            _userRepository.Insert(user);
        }

        public void RemoveUser(string id)
        {
            _userRepository.Remove(id);
        }
    }
}
