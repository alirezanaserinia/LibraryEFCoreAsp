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
        private readonly IBook_ShelfRepository _book_ShelfRepository;

        public UserService(IUserRepository userRepository, IShelfRepository shelfRepository, IBook_ShelfRepository book_ShelfRepository)
        {
            _userRepository = userRepository;
            _shelfRepository = shelfRepository;
            _book_ShelfRepository = book_ShelfRepository;
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

        public IEnumerable<UserWithCountOfBooks> GetNumOfBooksForUsers()
        {
            List<UserWithCountOfBooks> usersWithCountOfBooks = new List<UserWithCountOfBooks>();
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                var userShelfs = _shelfRepository.GetShelfsByUserId(user.Id);
                int countOfBooks = 0;
                foreach (Shelf shelf in userShelfs)
                {
                    var book_Shelfs = _book_ShelfRepository.GetBook_ShelfsByShelfId(shelf.Id);
                    if (book_Shelfs != null)
                    {
                        countOfBooks += book_Shelfs.Count();
                    }
                }
                usersWithCountOfBooks.Add(
                    new UserWithCountOfBooks()
                    {
                        UserName = user.UserName,
                        FullName = user.FullName,
                        CountOfBooks = countOfBooks
                    });
            }
            return usersWithCountOfBooks;
        }

        public IEnumerable<UserWithCountOfReadBooks> GetNumOfReadBooksForUsers()
        {
            List<UserWithCountOfReadBooks> usersWithCountOfReadBooks = new List<UserWithCountOfReadBooks>();
            int countOfReadBooks = 0;
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                var userShelfs = _shelfRepository.GetShelfsByUserId(user.Id);
                countOfReadBooks = 0;
                foreach (Shelf shelf in userShelfs)
                {
                    var book_Shelfs = _book_ShelfRepository.GetBook_ShelfsByShelfId(shelf.Id);
                    if (book_Shelfs != null)
                    {
                        foreach (var book_Shelf in book_Shelfs)
                        {
                            if (book_Shelf.StudyState == 1)
                            {
                                countOfReadBooks++;
                            }
                        }
                    }
                }
                usersWithCountOfReadBooks.Add(
                    new UserWithCountOfReadBooks()
                    {
                        UserName = user.UserName,
                        FullName = user.FullName,
                        CountOfReadBooks = countOfReadBooks
                    });
            }
            return usersWithCountOfReadBooks;
        }

        public IEnumerable<UserModel> GetUsersHaveAtLeastOneReadingBook()
        {
            List<UserModel> usersHaveAtLeastOneReadingBook = new List<UserModel>();
            var shelfs = _shelfRepository.GetAll();
            List<string> usersHaveAtLeastOneReadingBookIds = new List<string>();
            foreach (var shelf in shelfs)
            {
                bool isUserChecked = usersHaveAtLeastOneReadingBookIds.Contains(shelf.UserId);
                if (!isUserChecked)
                {
                    var book_Shels = _book_ShelfRepository.GetBook_ShelfsByShelfId(shelf.Id);
                    foreach (var book_Shelf in book_Shels)
                    {
                        if (book_Shelf.StudyState == 2)
                        {
                            usersHaveAtLeastOneReadingBookIds.Add(shelf.UserId);
                            usersHaveAtLeastOneReadingBook.Add(
                                new UserModel()
                                {
                                    UserName = shelf.User.UserName,
                                    FullName = shelf.User.FullName
                                });
                            break;
                        }
                    }
                }
            }
            return usersHaveAtLeastOneReadingBook;
        }

        public IEnumerable<UserStudyState> GetUsersStudyState()
        {
            List<UserStudyState> usersStudyState = new List<UserStudyState>();
            int countOfReadBooks = 0;
            int countOfReadingBooks = 0;
            int countOfFutureStudyBooks = 0;
            var users = _userRepository.GetAll();
            foreach (var user in users)
            {
                var userShelfs = _shelfRepository.GetShelfsByUserId(user.Id);
                countOfReadBooks = 0;
                countOfReadingBooks = 0;
                countOfFutureStudyBooks = 0;
                foreach (Shelf shelf in userShelfs)
                {
                    var book_Shelfs = _book_ShelfRepository.GetBook_ShelfsByShelfId(shelf.Id);
                    if (book_Shelfs != null)
                    {
                        foreach (var book_Shelf in book_Shelfs)
                        {
                            switch (book_Shelf.StudyState)
                            {
                                case 1:
                                    {
                                        countOfReadBooks++;
                                        break;
                                    }
                                case 2:
                                    {
                                        countOfReadingBooks++;
                                        break;
                                    }
                                case 3:
                                    {
                                        countOfFutureStudyBooks++;
                                        break;
                                    }
                                default:
                                    break;
                            }
                        }
                    }
                }
                usersStudyState.Add(
                    new UserStudyState()
                    {
                        UserName = user.UserName,
                        FullName = user.FullName,
                        CountOfReadBooks = countOfReadBooks,
                        CountOfReadingBooks = countOfReadingBooks,
                        CountOfFutureStudyBooks = countOfFutureStudyBooks
                    });
            }
            return usersStudyState;
        }

        public IEnumerable<UserWithCountOfReadBooks> GetOrderedListOfUsersBasedOnBooksRead()
        {
            var usersWithNumOfReadBooks = GetNumOfReadBooksForUsers();
            return usersWithNumOfReadBooks.OrderByDescending(u => u.CountOfReadBooks).ToList();
        }
    }
}
