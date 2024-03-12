using MobileShopShared.Models;
using MobileShopShared.Responses;

namespace MobileShopClient.Services
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featuredProducts);
    }
}
