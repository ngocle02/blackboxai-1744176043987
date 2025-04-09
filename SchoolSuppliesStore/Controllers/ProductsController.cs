using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSuppliesStore.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolSuppliesStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string category, string searchString)
        {
            var products = _context.Products.AsQueryable();
            
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
                ViewData["Category"] = category;
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => 
                    p.Name.Contains(searchString) || 
                    p.Description.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
            }

            ViewData["Categories"] = await _context.Products
                .Select(p => p.Category)
                .Distinct()
                .ToListAsync();

            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
                
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
