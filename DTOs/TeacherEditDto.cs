using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DTOs
{
    public class TeacherEditDto 
    {
        [HiddenInput]
        public Guid Id { get; set; }

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

        [Required]
        [Display(Name = "Field Of Study")]
        [StringLength(40, MinimumLength = 3)]
        public string FieldOfStudy { get; set; }

        [Required]
        [Display(Name = "Years Of Experience")]
        [Range(1, 70)]
        public int YearsOfExperience { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }
    }
}
