using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Models;

namespace RegistrationApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationContext _context;

        public RegistrationController(RegistrationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Hash the password (simple SHA256 for demo; use a stronger algorithm in production)
            using var sha = SHA256.Create();
            var hashed = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(model.Password ?? string.Empty)));

            var entity = new Registration
            {
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Address = model.Address,
                Country = model.Country,
                Username = model.Username,
                Password = hashed,
                AcceptTerms = model.AcceptTerms
            };

            _context.Registrations.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
