using AccessManager.Core.Data;
using AccessManager.Core.Interfaces;
using Model;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AccessManager.Web.Controllers
{
    public class FormSubmissionController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IFormSubmissionRepository _formSubmissionRepository;
        private readonly AppDbContext _context;
        private readonly ICountryRepository _countryRepository;
        private readonly ICityRepository _cityRepository;

        public FormSubmissionController(IWebHostEnvironment hostingEnvironment, IFormSubmissionRepository formSubmissionRepository, AppDbContext context ,ICountryRepository countryRepository,
            ICityRepository cityRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _formSubmissionRepository = formSubmissionRepository;
            _context = context;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }
      
        // ----------------------------
        // Submit Form
        // ----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(IFormFile Picture, FormSubmission model)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (Picture != null)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                        Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Picture.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Picture.CopyToAsync(stream);
                    }

                    model.PicturePath = "/uploads/" + uniqueFileName;
                }

                // Save to repository
                _formSubmissionRepository.Add(model);

                return Json(new { success = true, message = "Form submitted successfully!" });
            }

            return Json(new { success = false, message = "Validation failed!" });
        }




        // ----------------------------
        // All Records
        // ----------------------------
        [HttpGet]
        public IActionResult AllRecords()
        {
            var data = _formSubmissionRepository.GetAll();
            return View(data);
        }

        // ----------------------------
        // View Single Record
        // ----------------------------
        [HttpGet]
        public IActionResult ViewRecord(int id)
        {
            var record = _formSubmissionRepository.GetById(id);
            if (record == null)
                return NotFound();

            return View(record);
        }

        // ----------------------------
        // Edit Record (GET)
        // ----------------------------
        [HttpGet]
        public IActionResult EditRecord(int id)
        {
            var record = _formSubmissionRepository.GetById(id);
            if (record == null)
                return NotFound();

            return View(record);
        }

        // ----------------------------
        // Edit Record (POST)
        // ----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRecord(FormSubmission model)
        {
            if (ModelState.IsValid)
            {
                _formSubmissionRepository.Update(model);
                return RedirectToAction("AllRecords");
            }

            return View(model);
        }

        // ----------------------------
        // Delete Record
        // ----------------------------
        [HttpPost]
        public IActionResult DeleteRecord(int id)
        {
            _formSubmissionRepository.Delete(id);
            return Json(new { success = true });
        }

        // ----------------------------
        // Send Form via Email
        // ----------------------------



     

        [HttpPost]
        public async Task<IActionResult> SendFormEmail(int id, string toEmail)
        {
            var record = _formSubmissionRepository.GetById(id);
            if (record == null || string.IsNullOrWhiteSpace(toEmail))
                return Json(new { success = false });

            var messageBody = $@"
        <h3>User Form Details</h3>
        <p><strong>Name:</strong> {record.Name}</p>
        <p><strong>Father Name:</strong> {record.FatherName}</p>
        <p><strong>CNIC:</strong> {record.CNIC}</p>
        <p><strong>Email:</strong> {record.Email}</p>
        <p><strong>Phone:</strong> {record.Phone}</p>
        <p><strong>Marital Status:</strong> {record.MaritalStatus}</p>
        <p><strong>Address:</strong> {record.Address}</p>
        <p><strong>Age:</strong> {record.Age}</p>
        <p><strong>Date of Birth:</strong> {record.DOB:yyyy-MM-dd}</p>
        <p><strong>Nationality:</strong> {record.Nationality}</p>
        <p><strong>Occupation:</strong> {record.Occupation}</p>
        <p><strong>Gender:</strong> {record.Gender}</p>
        <p><strong>City:</strong> {record.City}</p>
        <p><strong>Country:</strong> {record.Country}</p>
        <p><strong>Country Code:</strong> {record.CountryCode}</p>
       {(string.IsNullOrEmpty(record.PicturePath) ? "" : "<p><strong>Picture:</strong><br/><img src='cid:UserImage' width='150'/></p>")}
           
    ";
           

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("hammadghazanfar43@gmail.com", "rjia tsra gbgk wvsr");

                var mail = new MailMessage();
                mail.From = new MailAddress("hammadghazanfar43@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Form Details";
                mail.IsBodyHtml = true;

                // Prepare HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageBody, null, "text/html");

                // Embed image if exists
                if (!string.IsNullOrEmpty(record.PicturePath))
                {
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, record.PicturePath.TrimStart('/'));
                    Console.WriteLine($"Looking for image at: {filePath}");

                    if (System.IO.File.Exists(filePath))
                    {
                        LinkedResource inlineImage = new LinkedResource(filePath);
                        inlineImage.ContentId = "UserImage";
                        inlineImage.ContentType.MediaType = "image/jpeg"; // change if png
                        inlineImage.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        htmlView.LinkedResources.Add(inlineImage);
                    }
                }

                mail.AlternateViews.Add(htmlView);

                try
                {
                    await smtp.SendMailAsync(mail);

                    record.EmailStatus = "Sent";
                    await _context.SaveChangesAsync();

                    return Json(new { success = true });
                }
                catch
                {
                    record.EmailStatus = "Failed";
                    await _context.SaveChangesAsync();

                    return Json(new { success = false });
                }
            }
        }


        // ----------------------------
        // Optional: Country → City AJAX
        // ----------------------------
       


        [HttpGet]
        public IActionResult GetCitiesByCountry(int countryId)
        {
            var cities = _cityRepository.GetByCountryId(countryId)
                                        .Select(c => new { id = c.Id, name = c.Name })
                                        .ToList();

            return Json(cities);
        }
    }
}
