using BehKhaan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehKhaan.Domain.IRepositories
{
    public interface IShelfRepository
    {
        public IEnumerable<Shelf> GetAll();
        public Shelf GetById(string id);
        public void Insert(Shelf entity);
        public void Edit(Shelf entity);
        public void Remove(string id);
    }
}
