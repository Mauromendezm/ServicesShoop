using BookService.Model;
using Microsoft.EntityFrameworkCore;

namespace BookService.Persistence
{
    public class LibreryContext : DbContext
    {
        public LibreryContext()
        {

        }
        public LibreryContext(DbContextOptions<LibreryContext> options) : base(options)
        {

        }

        public virtual DbSet<MaterialLibrary> MaterialLibrary { get; set; }
    }
}
