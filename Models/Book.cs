using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homepage.Models
{
    public class Book
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "Book ID must be at least 2 characters.")]
        [RegularExpression("^(B)[a-z,A-Z]*[0-9]{1,}")]
        public string BookId { get; set; }
        [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
        [MaxLength(50, ErrorMessage = "Name should not exceed 50 characters.")]
        public string BookTitle { get; set; }
        [Range(0, 100, ErrorMessage = "Price needs to be greater than $0 and less than $100.")]
        public double BookPrice { get; set; }
        [Range(0, 100, ErrorMessage = "Quantity needs to be less than 100.")]
        public int BookQuantity { get; set; }
        [MinLength(5, ErrorMessage = "The description must be at least 5 characters.")]
        public string BookDescription { get; set; }
        [Required]
        public string BookImage { get; set; }
        [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
        [MaxLength(30, ErrorMessage = "Name should not exceed 50 characters.")]
        public string BookAuthor { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
