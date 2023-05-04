using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Orders.DB
{
    public class OrdersDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersDBContext(DbContextOptions options) : base(options)
        {
        }

    }
}
