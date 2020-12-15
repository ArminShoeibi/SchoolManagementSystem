using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Identity
{
    public class Student : ApplicationUser
    {
        public string FatherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public string HomePhoneNumber { get; set; }
    }
}
