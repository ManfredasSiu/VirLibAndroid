using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstEFLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new VirtualLibEntities())
            {
                // Create and save a new Book
                /*Console.Write("Enter the name for a new Book: ");
                var name = Console.ReadLine();
                Console.Write("Enter the id for a new Book: ");
                var id = int.Parse(Console.ReadLine());
                Console.Write("Enter the author for a new Book: ");
                var author = Console.ReadLine();
                Console.Write("Enter the press for a new Book: ");
                var press = Console.ReadLine();
                Console.Write("Enter the barcode for a new Book: ");
                var barcode = Console.ReadLine();
                Console.Write("Enter the genre for a new Book: ");
                var genre = Console.ReadLine();
                Console.Write("Enter the pages for a new Book: ");
                var pages = int.Parse(Console.ReadLine());
                Console.Write("Enter the quantity for a new Book: ");
                var quantity = int.Parse(Console.ReadLine());

                string name = "Knyga", author = "Autorius", press = "Leidykla", barcode = "1351860514650", genre = "Drama";
                int id = 1015, pages = 180, quantity = 10;



                var book = new Book
                {
                    Name = name,
                    Id = id,
                    Author = author,
                    Barcode = barcode,
                    Genre = genre,
                    Pages = pages,
                    Press = press,
                    Quantity = quantity
                };
                db.Books.Add(book);
                db.SaveChanges();*/

                // Display all Books from the database
                var query = from b in db.Books
                            orderby b.Name
                            select b;

                Console.WriteLine("All books in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
