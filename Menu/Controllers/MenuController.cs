using Menu.Attributes;
using Menu.Context;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MyDBContext _context;
        public MenuController(MyDBContext context)
        {
            _context = context;
        }

        // Index - List all dishes
        public IActionResult Index()
        {
            var dishes = _context.Dishes.ToList();
            return View(dishes);
        }

        // Create
        [Auth("Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // Create - POST
        [Auth("Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Dish dish, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using var ms = new MemoryStream();
                    ImageFile.CopyTo(ms);
                    dish.ImageData = ms.ToArray();
                    dish.ImageMimeType = ImageFile.ContentType;
                }

                dish.CreatedAt = DateTime.Now;
                _context.Add(dish);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // Edit - Show form
        [Auth("Admin,Manager,Staff")]
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var dish = _context.Dishes.Find(id);
            if (dish == null) return NotFound();

            return View(dish);
        }

        // Edit - POST
        [Auth("Admin,Manager,Staff")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Dish dish, IFormFile? ImageFile)
        {
            if (id != dish.DishId) return RedirectToAction("Index");

            if (ModelState.IsValid)
            {
                try
                {
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        ImageFile.CopyTo(ms);
                        dish.ImageData = ms.ToArray();
                        dish.ImageMimeType = ImageFile.ContentType;
                    }
                    else
                    {
                        var existingDish = _context.Dishes.AsNoTracking().FirstOrDefault(d => d.DishId == id);
                        dish.ImageData = existingDish?.ImageData;
                        dish.ImageMimeType = existingDish?.ImageMimeType;
                    }

                    dish.CreatedAt = DateTime.Now;
                    _context.Update(dish);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DishExists(dish.DishId))
                        return RedirectToAction("Index");
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        [Auth("Admin,Manager")]
        // Delete - Show confirmation
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            var dish = _context.Dishes.FirstOrDefault(m => m.DishId == id);
            if (dish == null) return RedirectToAction("Index");

            return View(dish);
        }

        // Delete - POST confirmed
        [HttpPost, ActionName("Delete")]
        [Auth("Admin,Manager")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var dish = _context.Dishes.Find(id);
            if (dish != null)
            {
                _context.Dishes.Remove(dish);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.DishId == id);
        }
    }
}
