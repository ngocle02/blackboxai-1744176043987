using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSuppliesStore.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSuppliesStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var featuredProducts = await _context.Products
                .OrderByDescending(p => p.Id)
                .Take(8)
                .ToListAsync();
                
            ViewData["ProductCount"] = await _context.Products.CountAsync();
            ViewData["Categories"] = await _context.Products
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();
                
            return View(featuredProducts);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
