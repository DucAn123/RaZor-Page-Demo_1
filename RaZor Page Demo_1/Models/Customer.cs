using System.ComponentModel.DataAnnotations;
using RazorPagesLabA1.Validation; // ✅ Thêm dòng này

namespace RazorPagesLabA1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Customer name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The length of name is from 3 to 20 characters.")]
        [Display(Name = "Customer name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Customer email is required!")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Year of birth is required!")]
        [Display(Name = "Year of birth")]
        [Range(1960, 2000, ErrorMessage = "1960 - 2000")]
        [CustomerValidation] // ✅ Sử dụng class vừa tạo
        public int YearOfBirth { get; set; }
    }
}
