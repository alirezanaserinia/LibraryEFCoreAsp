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
        public IEnumerable<UserWithCountOfBooks> GetNumOfBooksForUsers();
        public IEnumerable<UserWithCountOfReadBooks> GetNumOfReadBooksForUsers();
        public IEnumerable<UserStudyState> GetUsersStudyState();
        public IEnumerable<UserModel> GetUsersHaveAtLeastOneReadingBook();
        public IEnumerable<UserWithCountOfReadBooks> GetOrderedListOfUsersBasedOnBooksRead();
    }
}
