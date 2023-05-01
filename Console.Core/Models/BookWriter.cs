
using Console.Core.Models.Base;

namespace Console.Core.Models
{
    public class BookWriter:BaseModel
    {
        private static int _id;
        public string SurName { get; set; }
        public int Age { get; set; }
        public List<Book> Books;

        public BookWriter(string name, string surname, int age)
        {
            _id++;
            Id = _id;
            Name = name;
            SurName = surname;
            Age = age;
            Books = new List<Book>();
            CreatedDate = DateTime.UtcNow.AddHours(4);
        }
        public override string ToString()
        {
            return $"Name:{Name}, Surname:{SurName}, Age:{Age}, CreatedDate:{CreatedDate}, UpdatedDate:{UpdatedDate}";
        }
    }
}
