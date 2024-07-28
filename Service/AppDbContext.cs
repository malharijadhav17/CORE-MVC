using CORE_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CORE_MVC.Service
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }   
       

        public DbSet<Student> Students { get; set; }
    }
}
