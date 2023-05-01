
using Console.Core.Models;
using Console.Data.Repositories.BookWriters;
using Console.Service.Services.Interfaces;

namespace Console.Service.Services.Implementations
{
    public class BookWriterService : IBookWriterService
    {
        private readonly BookWriterRepository _repository=new BookWriterRepository();
        public async Task<string> CreateAsync(string name,string surname,int age)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";
            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid surname";
            if(age <= 0)
            {
                return "Add valid age";
            }
            System.Console.ForegroundColor = ConsoleColor.Green;
            BookWriter bookwriter=new BookWriter(name,surname,age);
            await _repository.AddAsync(bookwriter);
            return "Successfully created";
        }

        public async Task<string> DeleteAsync(int id)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;

            BookWriter bookwriter = await _repository.GetAsync(bw=>bw.Id==id);

            if (bookwriter == null)
                return "bookwriter not found";

            await _repository.RemoveAsync(bookwriter);

            System.Console.ForegroundColor = ConsoleColor.Green;

            return "success";
        }

        public async Task GetAllAsync()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            foreach (var item in await _repository.GetAllAsync())
            {
                System.Console.WriteLine(item);
            }
        }

        public async Task<List<Book>> GetAllBooksAsync(int id)
        {
            BookWriter bookwriter = await _repository.GetAsync(bw=>bw.Id == id);
            if(bookwriter == null)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Bookwriter not found");
                return null;
            }
            return bookwriter.Books;
        }

        public async Task<BookWriter> GetAsync(int id)
        {
            BookWriter bookwriter = await _repository.GetAsync(bw => bw.Id == id);
            if (bookwriter == null)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Bookwriter not found");
                return null;
            }
            return bookwriter;
        }

        public async Task<string> UpdateAsync(int id,string name,string surname,int age)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            if (string.IsNullOrWhiteSpace(name))
                return "Add valid name";
            if (string.IsNullOrWhiteSpace(surname))
                return "Add valid surname";
            if (age <= 0)
            {
                return "Add valid age";
            }
            BookWriter bookwriter = await _repository.GetAsync(x=>x.Id==id);

            if (bookwriter == null)
            {
                return "Bookwriter not found";
            }
            bookwriter.Name = name;
            bookwriter.SurName= surname;
            bookwriter.Age = age;

            System.Console.ForegroundColor = ConsoleColor.Green;

            return "Updated";
        }
    }
}