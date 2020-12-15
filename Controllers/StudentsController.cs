using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Domain.Identity;
using SchoolManagementSystem.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolMgmtContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentsController(SchoolMgmtContext db,
            UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await _db.Students.ToListAsync();
            return View(students);
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher(StudentCreationDto studentCreationDto)
        {
            if (ModelState.IsValid)
            {
                var newStudent = new Student()
                {
                    Address = studentCreationDto.Address,
                    HomePhoneNumber = studentCreationDto.HomePhoneNumber,
                    PlaceOfBirth = studentCreationDto.PlaceOfBirth,
                    FatherName = studentCreationDto.FatherName,

                    BirthDate = studentCreationDto.BirthDate,
                    Email = studentCreationDto.Email,
                    FirstName = studentCreationDto.FirstName,
                    Gender = studentCreationDto.Gender,
                    LastName = studentCreationDto.LastName,
                    PhoneNumber = studentCreationDto.PhoneNumber,
                    UserName = studentCreationDto.UserName,
                    NationalCode = studentCreationDto.NationalCode,

                };

                IdentityResult createResult =
                    await _userManager.CreateAsync(newStudent, studentCreationDto.Password);

                if (createResult.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in createResult.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return View(studentCreationDto);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(studentCreationDto);


        }
    }
}
