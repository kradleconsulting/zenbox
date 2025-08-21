using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace zenbox.data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbContextOptionsBuilder<ApplicationDbContext> o = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("Server=tcp:kradle.database.windows.net,1433;Initial Catalog=zenbox;Persist Security Info=False;User ID=sdrobyshev;Password=sy%LLr]F6f,u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public ApplicationDbContext() : base(new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Todo-Sergey-Drobyshev;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskHeader> TaskHeaders { get; set; }
        public DbSet<TaskLine> TaskLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() });
        }
    }
}
