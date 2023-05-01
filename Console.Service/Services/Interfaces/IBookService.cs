
using Console.Core.Enums;
using Console.Core.Models;

namespace Console.Service.Services.Interfaces
{
    internal interface IBookService
    {
        public Task<string> CreateAsync(int id, string name, double price, double discountprice,BookCategory category);
        public Task<string> DeleteAsync(int bwid, int bookid);
        public Task<string> UpdateAsync(int bwid, int bookid, string name, double price, double discountprice);
        public Task<Book> GetAsync(int bwid, int bookid);
    }
}
