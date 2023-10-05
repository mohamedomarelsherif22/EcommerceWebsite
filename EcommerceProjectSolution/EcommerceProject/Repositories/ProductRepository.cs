using EcommerceProject.Data;
using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }

        public void AddProduct(Product product)
        {
            _db.Add(product);
            _db.SaveChanges();

        }
        public  void DeleteProduct(int productId)
        {
            Product product =  _db.products.Find(productId);
            _db.products.Remove(product);
            _db.SaveChanges();
        }


        /*public void EditProduct(Product product, int productId)
        {
            _db.products.Update(product);
            _db.SaveChanges();

        }

        public async Task<Product> ReturnEditProduct(int productId)
        {
            return await _db.products.FindAsync(productId);
        }*/

    }
}
