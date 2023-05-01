
using Console.Core.Enums;
using Console.Core.Models.Base;

namespace Console.Core.Models
{
    public class Book:BaseModel
    {
        private static int _id;
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public  BookWriter BookWriter { get; set; }
        public BookCategory Category { get; set; }

        public Book(string name, double price, double discountprice, BookWriter bookwriter, BookCategory category)
        {
            _id++;
            Id = _id;
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            BookWriter = bookwriter;
            Category=category;
        }

        public Book(string name, double price, double discountprice, BookCategory category, BookWriter bookwriter)
        {
            Name = name;
            Price = price;
            DiscountPrice = discountprice;
            Category = category;
            BookWriter = bookwriter;
        }
    }
}
