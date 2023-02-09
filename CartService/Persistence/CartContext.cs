using CartService.Model;
using Microsoft.EntityFrameworkCore;

namespace CartService.Persistence
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }


        public DbSet<SessionCart> SessionCart { get; set; }
        public DbSet<SessionCartDetail> SessionCartDetail { get; set; }
    }
}
