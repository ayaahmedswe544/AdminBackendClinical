using AdminBackendClinical.Models;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AdminBackendClinical.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var drugs=_context.Drugs.Take(10).ToList();
            foreach(var drug in drugs)
            {
                Console.WriteLine("Drug name: " + drug.CommercialNameEn);
            }
          
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
