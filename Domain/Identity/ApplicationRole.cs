using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolManagementSystem.Domain.Identity
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
