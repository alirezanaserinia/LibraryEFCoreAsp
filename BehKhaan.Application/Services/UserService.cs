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
        private readonly IShelfRepository _shelfRepository;

        public UserService(IUserRepository userRepository, IShelfRepository shelfRepository)
        {
            _userRepository = userRepository;
            _shelfRepository = shelfRepository;
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


        public UserWithShelfsModel GetUserWithShelfsByUserId(string userId)
        {

            var shelfs = _shelfRepository.GetShelfsByUserId(userId);

            var user = shelfs.FirstOrDefault()?.User;

            if (user == null)
            {
                return null;
            }

            var userWithShelfs = new UserWithShelfsModel()
            {
                UserName = user.UserName,
                FullName = user.FullName,
                ShelfNames = shelfs.Select(s => s.Name).ToList()
            };

            return userWithShelfs;
        }
    }
}
