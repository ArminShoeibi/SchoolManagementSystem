using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DTOs
{
    public class ApplicationUserCreationDto
    {
        [Required]
        [Display(Name = "User Name")]
        [StringLength(30, MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        [StringLength(120, MinimumLength = 8)]
        public string Email { get; set; }

        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "National Code")]
        [StringLength(10, MinimumLength = 10)]
        public string NationalCode { get; set; }


        [DataType(DataType.Password)]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
