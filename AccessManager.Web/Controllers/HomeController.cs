using AccessManager.Core.Interfaces;
using Model;

using AccessManager.Infrastructure.Repositories;
using AccessManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AccessManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryRepository _countryRepository;

        public HomeController(ILogger<HomeController> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

      
        public IActionResult Dashboard()
        {
            // Get all countries from repository
            var countries = _countryRepository.GetAllCountries();

            // Pass to view
            ViewBag.Countries = countries ?? new List<Country>(); // avoid null

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
