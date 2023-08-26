using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        [ExistingAuthor]
        public string AuthorId { get; set; }
        public string Cover { get; set; }



        public override string ToString()
        {
            return $"Book[Id={Id} , Title={Title} ]";
        }
    }
}
