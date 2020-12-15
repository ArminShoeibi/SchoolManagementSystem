using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class TeachersController : Controller
    {
        private readonly SchoolMgmtContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeachersController(SchoolMgmtContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<Teacher> teachers = await _db.Teachers.ToListAsync();
            return View(teachers);
        }

        public IActionResult CreateTeacher()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTeacher(TeacherCreationDto teacherCreationDto)
        {
            if (ModelState.IsValid)
            {
                var newTeacher = new Teacher()
                {
                    AcademicDegree = teacherCreationDto.AcademicDegree,
                    FieldOfStudy = teacherCreationDto.FieldOfStudy,
                    YearsOfExperience = teacherCreationDto.YearsOfExperience,
                    BirthDate = teacherCreationDto.BirthDate,
                    Email = teacherCreationDto.Email,
                    FirstName = teacherCreationDto.FirstName,
                    Gender = teacherCreationDto.Gender,
                    LastName = teacherCreationDto.LastName,
                    PhoneNumber = teacherCreationDto.PhoneNumber,
                    UserName = teacherCreationDto.UserName,
                    NationalCode = teacherCreationDto.NationalCode,

                };

                IdentityResult createResult =
                    await _userManager.CreateAsync(newTeacher, teacherCreationDto.Password);

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
                    return View(teacherCreationDto);
                }

                return RedirectToAction(nameof(Index));
            }

            return View(teacherCreationDto);


        }



        public async Task<IActionResult> EditTeacher(Guid id)
        {
            Teacher teacherToEdit = await _db.Teachers.FindAsync(id);
            if (teacherToEdit is null)
            {
                return NotFound();
            }

            TeacherEditDto teacherEditDto = new()
            {
                AcademicDegree = teacherToEdit.AcademicDegree,
                BirthDate = teacherToEdit.BirthDate,
                Email = teacherToEdit.Email,
                FirstName = teacherToEdit.FirstName,
                LastName = teacherToEdit.LastName,
                Gender = teacherToEdit.Gender,
                FieldOfStudy = teacherToEdit.FieldOfStudy,
                NationalCode = teacherToEdit.NationalCode,
                Id = teacherToEdit.Id,
                PhoneNumber = teacherToEdit.PhoneNumber,
                UserName = teacherToEdit.UserName,
                YearsOfExperience = teacherToEdit.YearsOfExperience
            };
            return View(teacherEditDto);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> EditTeacher(TeacherEditDto teacherEditDto)
        {
            if (ModelState.IsValid)
            {
                /* Change Detection Update */
                Teacher teacherToEdit = await _db.Teachers.FindAsync(teacherEditDto.Id);

                teacherToEdit.AcademicDegree = teacherEditDto.AcademicDegree;
                teacherToEdit.BirthDate = teacherEditDto.BirthDate;
                teacherToEdit.Email = teacherEditDto.Email;
                teacherToEdit.FirstName = teacherEditDto.FirstName;
                teacherToEdit.LastName = teacherEditDto.LastName;
                teacherToEdit.NationalCode = teacherEditDto.NationalCode;
                teacherToEdit.PhoneNumber = teacherEditDto.PhoneNumber;
                teacherToEdit.UserName = teacherEditDto.UserName;
                teacherToEdit.Gender = teacherEditDto.Gender;
                teacherToEdit.FieldOfStudy = teacherEditDto.FieldOfStudy;
                teacherToEdit.ConcurrencyStamp = Guid.NewGuid().ToString();

                await _userManager.UpdateNormalizedEmailAsync(teacherToEdit);
                await _userManager.UpdateNormalizedUserNameAsync(teacherToEdit);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(teacherEditDto);
        }

        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            Teacher teacherToDelete = await _db.Teachers.FindAsync(id);
            if (teacherToDelete is null)
            {
                return NotFound();
            }

            _db.Teachers.Remove(teacherToDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
