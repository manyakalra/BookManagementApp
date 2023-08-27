using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Review
    {
        public string Id { get; set; }
        public string Rating { get; set; }

        public string Title { get; set; }
        public string ReviewDetails { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
