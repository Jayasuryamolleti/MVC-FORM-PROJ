using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationApp.Models
{
    public class Registration
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
    public string? FullName { get; set; }

        [Required]
        [EmailAddress]
    public string? Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
    public string? PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
    public string? Gender { get; set; }

        [Required]
    public string? Address { get; set; }

        [Required]
    public string? Country { get; set; }

        [Required]
    public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
    public string? Password { get; set; }

    [NotMapped]
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Accept Terms and Conditions")]
        public bool AcceptTerms { get; set; }
    }
}