using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    public class User
    {
        [Email]
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        [Column("PhotoUrl")]
        public string Photo { get; set; }
    }
}