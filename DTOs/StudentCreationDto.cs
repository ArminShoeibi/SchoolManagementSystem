using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DTOs
{
    public class StudentCreationDto : ApplicationUserCreationDto
    {

        [Required]
        [Display(Name = "Father Name")]
        [StringLength(25, MinimumLength = 3)]
        public string FatherName { get; set; }

        [Required]
        [Display(Name = "Place Of Birth")]
        [StringLength(25, MinimumLength = 3)]
        public string PlaceOfBirth { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Home Phone Number")]
        [StringLength(11, MinimumLength = 11)]
        public string HomePhoneNumber { get; set; }
    }
}
