using GameShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Controllers
{
    public class MakesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MakesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var makes = _context.Makes.Include(m => m.Games).ToList();
            return View(makes);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Make make)
        {
            _context.Makes.Add(make);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
    }
}
