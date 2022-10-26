using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Homepage.Models
{
    public class Book
    {

        public int Id { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Book ID must have 2 characters")]
        public string BId { get; set; }

        [MinLength(3, ErrorMessage = "Title length must be at least 5 characters")]
        [MaxLength(30, ErrorMessage = "Max title length is 30 characters")]
        public string Title { get; set; }
        [Required]
        public string Category { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Price must be from 1 to 100")]
        public double Price { get; set; }

        [Range(1, 200, ErrorMessage = "Quanity must be from 1 to 200")]
        public int Quantity { get; set; }

        [MinLength(100, ErrorMessage = "Title length must be at least 100 characters")]
        [MaxLength(3000, ErrorMessage = "Max title length is 3000 characters")]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Image { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
