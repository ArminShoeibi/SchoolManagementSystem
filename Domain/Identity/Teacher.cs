using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Identity
{
    public class Teacher : ApplicationUser
    {
        public string FieldOfStudy { get; set; }
        public AcademicDegree AcademicDegree{ get; set; }
        public int YearsOfExperience { get; set; }
    }
}
