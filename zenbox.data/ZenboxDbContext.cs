using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using zenbox.model;

namespace zenbox.data
{
    public class ZenboxDbContext : IdentityDbContext<ApplicationUser>
    {
        DbContextOptionsBuilder<ZenboxDbContext> o = new DbContextOptionsBuilder<ZenboxDbContext>()
                .UseSqlServer("Server=tcp:kradle.database.windows.net,1433;Initial Catalog=zenbox;Persist Security Info=False;User ID=sdrobyshev;Password=sy%LLr]F6f,u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public ZenboxDbContext() : base(new DbContextOptionsBuilder().UseSqlServer("Server=tcp:kradle.database.windows.net,1433;Initial Catalog=zenbox;Persist Security Info=False;User ID=sdrobyshev;Password=sy%LLr]F6f,u;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;").Options)
        {

        }

        public ZenboxDbContext(DbContextOptions<ZenboxDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskHeader> TaskHeaders { get; set; }
        public DbSet<TaskLine> TaskLines { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
