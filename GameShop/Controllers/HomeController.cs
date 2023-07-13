using GameShop.Data;
using GameShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace GameShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            
            ApplicationDbContext context)
        {
            _logger = logger;

            _context = context;
        }
        public IActionResult Index()
        {
            
            var topGames = _context.Games.Where(g => g.IsTopGame);
            var trendingGames = _context.Games.Where(g => g.IsTrendingGame);
            Dictionary<string, IEnumerable<object>> col = new Dictionary<string, IEnumerable<object>>();
            col["TopGames"] = topGames;
            col["TrendingGames"] = trendingGames;
            

            return View(col);
        }
        [HttpGet]
        public IActionResult Shop()
        {
            var games = _context.Games.Include(c => c.Make).ToList();

            return View(games);
        }

        public IActionResult Contact()
        {
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