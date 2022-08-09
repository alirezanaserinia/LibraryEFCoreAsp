using BehKhaan.Application.Interfaces;
using BehKhaan.Application.Models;
using BehKhaan.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Services
{
    public class ModelValidator : IModelValidator
    {
        private readonly IBookRepository _bookRepository;
        private readonly IShelfRepository _shelfRepository;
        private readonly IBook_ShelfRepository _book_shelfRepository;
        private readonly IUserRepository _userRepository;

        private readonly IUserService _userService;

        public ModelValidator(IBookRepository bookRepository, IShelfRepository shelfRepository,
            IBook_ShelfRepository book_shelfRepository, IUserRepository userRepository, IUserService userService)
        {
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;
            _book_shelfRepository = book_shelfRepository;
            _userRepository = userRepository;
            _userService = userService;
        }

        public ValidationModel CheckBookModelValidation(BookModel bookModel)
        {
            int bookRate = bookModel.Rate;
            if (bookRate < 1 || bookRate > 5)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "Rate of book can be between 1 and 5!"
                };
            }
            else
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "BookModel is valid"
                };
            }
        }

        public ValidationModel CheckBook_ShelfModelValidation(Book_ShelfModel book_ShelfModel)
        {
            var book = _bookRepository.GetById(book_ShelfModel.BookId);
            if (book == null)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "Book not found!"
                };
            }

            var shelf = _shelfRepository.GetById(book_ShelfModel.ShelfId);
            if (shelf == null)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "Shelf not found!"
                };
            }
            int studyState = book_ShelfModel.StudyState;
            if (studyState < 1 || studyState > 3)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "StudyState can be 1, 2 or 3!"
                };
            }
            else
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "Book_ShelfModel is valid"
                };
            }
        }

        public ValidationModel CheckShelfModelValidation(ShelfModel shelfModel)
        {
            var user = _userRepository.GetById(shelfModel.UserId);
            if (user == null)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "User not found!"
                };
            }
            else
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "ShelfModel is valid"
                };
            }
        }

        public ValidationModel CheckShelfNameUniquenessForUser(string userId, string shelfName)
        {
            var userWithShelfs = _userService.GetUserWithShelfsByUserId(userId);
            if (userWithShelfs == null)
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "This shelfName is available"
                };
            }
            bool isExists = userWithShelfs.ShelfNames.Contains(shelfName);
            if (isExists)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "This shelfName is already exists for " + userWithShelfs.FullName + "!"
                };
            }
            else
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "This shelfName is available"
                };
            }
        }

        public ValidationModel CheckUserNameUniqueness(string userName)
        {
            bool isUserNameExists = _userRepository.isUserNameExists(userName);
            if (isUserNameExists)
            {
                return new ValidationModel()
                {
                    Success = false,
                    Message = "This username is unavailable!"
                };
            }
            else
            {
                return new ValidationModel()
                {
                    Success = true,
                    Message = "This username is available"
                };
            }
        }
    }
}
