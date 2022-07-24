// See https://aka.ms/new-console-template for more information
using Migrations_ConsoleApp.Code_First;
using Migrations_ConsoleApp.Code_First.Entity;

Console.WriteLine("Hello, World!");

using (var ctx = new SchoolContext())
{
    ctx.Add(new Student() {  Name = "Ram", City="Blore" });
    ctx.Add(new Student() { Name = "Shyam", City = "Singapore" });
    ctx.Add(new Student() { Name = "Radhe", City = "Masachu" });
    ctx.Add(new Student() { Name = "Prasad", City = "Rhodes" });
    ctx.Add(new Student() { Name = "Thulasi", City = "Mumb" });

    ctx.Students.Add(new Student() { Name = "Sai", City = "LA" });
    ctx.SaveChanges();
}
