using Microsoft.EntityFrameworkCore;
using MobileShopServer.Data;
using MobileShopShared.Models;
using MobileShopShared.Responses;

namespace MobileShopServer.Repositories
{
    public class ProductRepository(AppDbContext appDbContext) : IProduct
    {
        private readonly AppDbContext appDbContext = appDbContext;

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var (flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                appDbContext.Products.Add(model);
                await Commit();
                return new ServiceResponse(true, "Product Saved");
            }
            return new ServiceResponse(flag, message);
        }

        public async Task<List<Product>> GetAllProducts(bool featuredProducts)
        {
            if (featuredProducts)
                return await appDbContext.Products
                    .Where(_ => _.Featured)
                    .ToListAsync();
            else
                return await appDbContext.Products
                    .ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await appDbContext.Products
                .FirstOrDefaultAsync(x =>
                x.Name!.ToLower()!
                .Equals(name.ToLower()));

            return product is null ? new ServiceResponse(true, null!) :
                new ServiceResponse(false, "Product already exist");
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();
    }
}
