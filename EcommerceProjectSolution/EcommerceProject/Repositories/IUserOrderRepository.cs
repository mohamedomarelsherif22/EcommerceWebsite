using EcommerceProject.Models;

namespace EcommerceProject.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();

    }
}