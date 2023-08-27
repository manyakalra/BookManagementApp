using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Review
    {
        public string ReviewerEmail { get; set; }
        public string BookId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
