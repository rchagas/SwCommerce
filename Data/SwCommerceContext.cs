using Microsoft.EntityFrameworkCore;

namespace SwCommerce.Models
{
    public class SwCommerceContext : DbContext
    {
        public SwCommerceContext (DbContextOptions<SwCommerceContext> options) : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Offer> Offer { get; set; }
    }
}
