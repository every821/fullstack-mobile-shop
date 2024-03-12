using Microsoft.EntityFrameworkCore;
using MobileShopShared.Models;
namespace MobileShopServer.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
    }
}
