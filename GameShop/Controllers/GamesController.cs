using GameShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var games = _context.Games.Include(g => g.Make).ToList();
            return View(games);
        }
        [HttpPost]
        public async  Task<IActionResult> Add(Game Game)
        {
            var game = new Game
            {
                Name = Game.Name,
                Description = Game.Description,
                Price = Game.Price,
                Image = Game.Image,
                Genre = Game.Genre,
                MakeId = Game.MakeId,
            };
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            var makes = _context.Makes.ToList();
            ViewBag.Makes = makes;
            return View();
        }

        public IActionResult Details(int id)
        {
            Game? game = _context.Games.Include(g=>g.Make).FirstOrDefault(g=>g.Id==id);
            var relGames = _context.Games.Where(g => g.Genre == game.Genre);
            ViewBag.RelGames = relGames.ToList();
            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Game? game = await _context.Games.FindAsync(id);
            var Makes = _context.Makes.ToList();
            ViewBag.Makes = Makes;

            return View(game);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var game = _context.Games.Find(id);
            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        
    }
}
