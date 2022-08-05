namespace BehKhaan.Application.Models
{
    public class InsertBookModel
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
    }
}
