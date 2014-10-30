using ReadingList.Validators;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [AuthorIsFamousValidator("Name", ErrorMessage = "The author must be famous enough to have a Wiki!")]
        public string Name { get; set; }

    }

 
}