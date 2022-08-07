using BehKhaan.Application.Models;
using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Application.Interfaces
{
    public interface IShelfService
    {
        public IEnumerable<Shelf> GetShelfs();
        public Shelf GetShelfById(string id);
        public void InsertShelfForUser(ShelfModel shelfModel);
        public void EditShelf(string id, ShelfModel shelfModel);
        public void RemoveShelf(string id);
    }
}
