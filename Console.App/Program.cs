using Console.Service.Services.Implementations;

BookWriterService BookWriterService= new BookWriterService();

System.Console.WriteLine("Add name");
string name=System.Console.ReadLine();
System.Console.WriteLine("Add surname");
string surname=System.Console.ReadLine();
System.Console.WriteLine("Add age");
int age=int.Parse(System.Console.ReadLine());


string result=await BookWriterService.CreateAsync(name, surname, age);
