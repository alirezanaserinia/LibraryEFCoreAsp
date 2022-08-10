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
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _shelfRepository;
        public ShelfService(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }

        public void EditShelf(string id, string newShelfName)
        {
            var shelf = _shelfRepository.GetById(id);
            if (shelf != null)
            {
                shelf.Name = newShelfName;
                _shelfRepository.Edit(shelf);
            }
        }

        public Shelf GetShelfById(string id)
        {
            return _shelfRepository.GetById(id);
        }

        public IEnumerable<Shelf> GetShelfs()
        {
            return _shelfRepository.GetAll();
        }

        public void InsertShelfForUser(ShelfModel shelfModel)
        {
            Shelf shelf = new Shelf()
            {
                Id = Guid.NewGuid().ToString(),
                Name = shelfModel.Name,
                UserId = shelfModel.UserId
            };
            _shelfRepository.Insert(shelf);
        }

        public void RemoveShelf(string id)
        {
            _shelfRepository.Remove(id);
        }
    }
}
