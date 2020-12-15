using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.DTOs
{
    public class TeacherCreationDto : ApplicationUserCreationDto
    {
        [Required]
        [Display(Name = "Field Of Study")]
        [StringLength(40, MinimumLength = 3)]
        public string FieldOfStudy { get; set; }

        public AcademicDegree AcademicDegree { get; set; }

        [Required]
        [Display(Name = "Years Of Experience")]  
        [Range(1,70)]
        public int YearsOfExperience { get; set; }
    }
}
