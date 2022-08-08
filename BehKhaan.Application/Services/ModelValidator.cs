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

        public ModelValidator(IBookRepository bookRepository, IShelfRepository shelfRepository,
            IBook_ShelfRepository book_shelfRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _shelfRepository = shelfRepository;
            _book_shelfRepository = book_shelfRepository;
            _userRepository = userRepository;
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
    }
}
