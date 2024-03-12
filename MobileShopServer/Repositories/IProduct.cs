using MobileShopShared.Models;
using MobileShopShared.Responses;

namespace MobileShopServer.Repositories
{
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featuredProducts);
    }
}
