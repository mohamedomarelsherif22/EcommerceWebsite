using EcommerceProject.Data;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EcommerceProject.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;
        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int CategoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (
                            from Product in _db.products
                            join Category in _db.Categories
                            on Product.CategoryId equals Category.Id
                            where string.IsNullOrWhiteSpace(sTerm) || (Product != null && Product.ProductName.ToLower().StartsWith(sTerm))
                            select new Product
                            {
                                Id = Product.Id,
                                ProductImage = Product.ProductImage,
                                ProductName = Product.ProductName,
                                CategoryId = Product.CategoryId,
                                Price = Product.Price,
                                CategoryName = Category.CategoryName
                            }
                            ).ToListAsync();
            if (CategoryId > 0)
            {
                products = products.Where(a => a.CategoryId == CategoryId).ToList();
            }
            return products;
        }
    }
}
