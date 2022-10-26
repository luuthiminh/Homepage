using System.ComponentModel.DataAnnotations;
using System;

namespace Homepage.Models
{
    public class Customer
    {
            public int Id { get; set; }


            [MinLength(2, ErrorMessage = "Customer ID must be at least 2 characters.")]
            //[RegularExpression("^(C)[a-z,A-Z]*[0-9]{2,}")]
            public string CId { get; set; }


            [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
            [MaxLength(30, ErrorMessage = "Name should not exceed 30 characters.")]
            public string CName { get; set; }


            [Required]
            [EmailAddress]
            public string CEmail { get; set; }


            [Required]
            public char CGender { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime CBirthday { get; set; }

            public string CAddress { get; set; }


            [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be have 10 digits.")]
            public string CPhone { get; set; }

            [MinLength(5, ErrorMessage = "Username must be at least 5 characters.")]
            [MaxLength(10, ErrorMessage = "Username should not exceed 10 characters.")]
            public string CUsername { get; set; }
            [Required]
            public string CPassword { get; set; }
            [Required]
            public string CAvatar { get; set; }
        }
}
