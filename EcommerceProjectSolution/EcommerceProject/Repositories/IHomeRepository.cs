using EcommerceProject.Models;
using Humanizer.Localisation;

namespace EcommerceProject.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Product>> GetProducts(string sTerm = "", int CategoryId = 0);
        Task<IEnumerable<Category>> Categories();
    }
}
