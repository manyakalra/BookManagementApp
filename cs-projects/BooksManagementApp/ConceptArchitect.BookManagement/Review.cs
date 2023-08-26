using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class Review
    {
        public string Id { get; set; }
        public string Rating { get; set; }

        public string ReviewDetails { get; set; }

        public User User { get; set; }
    }
}
