using EcommerceProject.Data;
using EcommerceProject.Models;
using EcommerceProject.Repositories;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public ApplicationDbContext DB;

        public CategoryController(ILogger<HomeController> logger,  ApplicationDbContext db)
        {
            _logger = logger;
            DB = db;
        }

        

        public IActionResult Index()
        {
            List<Category> categories = DB.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Category category)
        {
            if (category.CategoryName != null)
            {
                DB.Add(category);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New", category);
            }

        }

        public IActionResult Delete(int categoryId)
        {
            Category category = DB.Categories.Find(categoryId);
            DB.Categories.Remove(category);
            DB.SaveChanges();
            return RedirectToAction("Index");
        }



       
        public IActionResult Edit(int id)
        {
            var category = DB.Categories.Find(id);

            if (category == null)
            {
                return NotFound(); 
            }

            return View(category); 
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (category.CategoryName != null)
            {
                DB.Update(category);
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
