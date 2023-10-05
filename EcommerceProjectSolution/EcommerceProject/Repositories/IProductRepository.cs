using EcommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Category>> Categories();
        void AddProduct(Product product);
        void DeleteProduct(int productId);
        /*void EditProduct(Product product, [FromRoute] int productId);
        Task<Product> ReturnEditProduct(int productId);*/
    }
}