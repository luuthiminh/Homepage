using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homepage.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(4, ErrorMessage = "Category ID must be at least 4 characters.")]
        [RegularExpression("^(CAT)[a-z,A-Z]*[0-9]{1,}")]
        public string CatId { get; set; }
        [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
        [MaxLength(30, ErrorMessage = "Name should not exceed 30 characters.")]
        public string CatName { get; set; }
        [MinLength(5, ErrorMessage = "Name length must be at least 5 character.")]
        public string CatDescription { get; set; }
        public int Status { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
