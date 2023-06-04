using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class User
    {
        [Key] 
        public Guid UserId { get; set; }

        [Required(ErrorMessage = " User Name is Required")]
        [MinLength(3, ErrorMessage = "User Name is too short")]
        [MaxLength(20, ErrorMessage = "User Name is too long")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

       // public string FirstName { get; set; }
       // public string LastName { get; set; }

        [Required]
        [MinLength(13, ErrorMessage = "ID Number is too short")]
        [MaxLength(14, ErrorMessage = "ID Number is too long")]
        [StringLength(13)]
        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        public bool IsEmailVerified { get; set; }

        public Guid? ActivationCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters required")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [MinLength(4, ErrorMessage = "Minimum 4 characters required")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match")]
        public string ConfirmPassword { get; set; }

        public string? ResetPasswordCode { get; set; }

        public string? LastLoginDate { get; set; }
    }
}
