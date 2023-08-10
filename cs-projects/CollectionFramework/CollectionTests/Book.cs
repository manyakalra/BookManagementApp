using ConceptArchitect.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConceptArchitect.Collections.Extensions;

namespace CollectionTests
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public int Price { get; set; }

        public double Rating { get; set; }

    }

    public class BookDb
    {
        public IIndexedList<Book> Books
        {
            get
            {
                return new DynamicArray<Book>(5)
                            .AddAll(
                                new Book() { Title="The Accursed God",Author="Vivek Dutta Mishra", Price=299, Rating=4.6},
                                new Book() { Title = "Manas", Author = "Vivek Dutta Mishra", Price = 199, Rating = 4.3 },
                                new Book() { Title = "Asura", Author = "Anant Neelkanthan", Price = 399, Rating = 3.6 },
                                new Book() { Title = "Ajaya", Author = "Anant Neelkanthan", Price = 499, Rating = 3.9 },
                                new Book() { Title = "Immortals of Meluha", Author = "Amish", Price = 499, Rating = 4.8 }
                            );
                
            }
        }
    }
}
