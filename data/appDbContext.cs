using EcommerceApp.models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.data
{
    public class appDbContext : DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options) 
        {
            
        }

        public DbSet<User> userTable { get; set; }
        public DbSet<Order> orderTable { get; set; }
        public DbSet<Products> productsTable { get; set; }
        public DbSet<OrderStatus> statusTable { get; set; }
        public DbSet<Seller> sellerTable { get; set; }  
    }
}
