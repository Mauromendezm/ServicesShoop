using AutorService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace AutorService.Persistence
{
    public class AutorContext : DbContext
    {
        public AutorContext(DbContextOptions<AutorContext> options) : base(options)
        {

        }
        public DbSet<AutorBook> AutorBook {get; set;}
        public DbSet<AcademicDegree> AcademicDegree { get; set;}
    }
}
