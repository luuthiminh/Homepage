using System.ComponentModel.DataAnnotations;

namespace Homepage.Models
{
    public class StoreOwner
    {
        public int Id { get; set; }
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Store Owner ID must be have 2 characters")]
        //   [RegularExpression("^(S)[a-z,A-Z]*[0-9]{2}$")] //SId phải bắt đầu bằng S và kết thúc là 2 chữ số
        public string SId { get; set; }
        [MinLength(1, ErrorMessage = "Name length must be at least 1 character.")]
        [MaxLength(30, ErrorMessage = "Name should not exceed 30 characters.")]
        public string SName { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be have 10 digits.")]
        public string SPhone { get; set; }
        [Required]
        public char SGender { get; set; }
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters.")]
        [MaxLength(10, ErrorMessage = "Username should not exceed 10 characters.")]
        public string SUsername { get; set; }
        [Required]
        public string SPassword { get; set; }
        public string SAvatar { get; set; }
    }
}
