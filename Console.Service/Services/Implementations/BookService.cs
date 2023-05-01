
using Console.Core.Enums;
using Console.Core.Models;
using Console.Data.Repositories.BookWriters;
using Console.Service.Services.Interfaces;


namespace Console.Service.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly BookWriterRepository _repository=new BookWriterRepository();
        public async Task<string> CreateAsync(int id, string name, double price, double discountprice, BookCategory category)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(bw=>bw.Id==id);

            if (await ValidateBook(name, price, discountprice) != null)
            {
                return await ValidateBook(name, price, discountprice);
            }
            Book book = new Book(name, price, discountprice, category, bookwriter);

            bookwriter.Books.Add(book);

            System.Console.ForegroundColor= ConsoleColor.Green;
            return "Created";
        }

        public async Task<string> DeleteAsync(int bwid, int bookid)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(bw => bw.Id == bwid);

            if (bookwriter == null)
                return "Bookwriter not found";

            Book book=bookwriter.Books.FirstOrDefault(book=>book.Id==bookid);

            if (book == null)
                return "Book not found";

            bookwriter.Books.Remove(book);
            System.Console.ForegroundColor=(ConsoleColor)ConsoleColor.Green;
            return "Deleted";
        }

        public async Task<Book> GetAsync(int bwid, int bookid)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(bw => bw.Id == bwid);

            if (bookwriter == null)
            {
                System.Console.WriteLine("Bookwriter not found");
                return null;
            }

            Book book = bookwriter.Books.FirstOrDefault(book => book.Id == bookid);

            if (book == null)
            {
                System.Console.WriteLine("Book not found");
                return null;
            }
            return book; 
        }

        public async Task<string> UpdateAsync(int bwid, int bookid, string name, double price, double discountprice)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(bw => bw.Id == bwid);

            if (bookwriter == null)
                return "Bookwriter not found";

            if(await ValidateBook(name, price, discountprice)!=null)
            {
                return await ValidateBook(name, price, discountprice);
            }

            Book book=bookwriter.Books.FirstOrDefault(book=>book.Id == bookid);

            book.Name = name;
            book.Price = price;
            book.DiscountPrice = discountprice;

            return "Deleted";
        }


        private async Task<string> ValidateBook(string name, double price, double discountprice)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";

            if (price <= 0)
                return "Add valid price";

            if (discountprice > price || discountprice <= 0)
                return "Add valid discountprice";

            return null;
        }
    }
}
