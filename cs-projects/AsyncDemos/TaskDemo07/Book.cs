using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public int Price { get; set; }

        public double Rating { get; set; }

        public override string ToString()
        {
            return $"Book[ Rating:{Rating}\tPrice={Price}\tAuthor={Author}\tTitle={Title}";
        }

    }

   
}
