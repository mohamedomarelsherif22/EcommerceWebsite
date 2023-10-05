using EcommerceProject.Data;
using EcommerceProject.Models;
using EcommerceProject.Repositories;
using EcommerceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IHomeRepository _homeRepository;
        private readonly ApplicationDbContext DB;

        public ProductController(ILogger<HomeController> logger, IProductRepository productRepository, IHomeRepository homeRepository, ApplicationDbContext db)
        {
            _productRepository = productRepository;
            _logger = logger;
            _homeRepository = homeRepository;
            DB = db;
        }

        public IActionResult Index()
        {
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> New()
        {
            ViewBag.categories = await _productRepository.Categories();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(Product product)
        {
            if (product.ProductName != null)
            {
                _productRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.categories = await _productRepository.Categories();
                return View("New", product);
            }

        }

        public IActionResult Delete(int productId)
        {
            _productRepository.DeleteProduct(productId);
            return RedirectToAction("Index");
        }



        
        public async Task<IActionResult> Edit(int id)
        {
            var product = DB.products.Find(id);

            if (product == null)
            {
                return NotFound(); 
            }

            
            ViewBag.categories = await _productRepository.Categories();


            return View(product); 
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (product.ProductName != null)
            {
                DB.Update(product);
                DB.SaveChanges();
                return RedirectToAction("Index"); 
            }

            ViewBag.categories = await _productRepository.Categories();

            return View(product);
        }




    }
}
