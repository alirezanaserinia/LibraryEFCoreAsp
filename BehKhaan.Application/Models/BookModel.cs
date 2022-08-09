﻿namespace BehKhaan.Application.Models
{
    public class BookModel
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
    }

    public class BookWithShelfsModel
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
        public List<string>? ShelfNames { get; set; }
    }
    public class BookWithNumOfReadersModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumOfReaders { get; set; }
    }
}
