using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Koko.Server.Domain;

namespace Koko.Server.DataAccess
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<AppUserLogin> AppUserLogins { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
              .HasMany(x => x.Logins)
              .WithOne(x => x.User)
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
             .HasMany(x => x.Tracks)
             .WithOne(x => x.CreatedBy)
             .HasForeignKey(x => x.CreatedById)
             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUserLogin>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(p => p.IPAddress).IsRequired(true);
                e.Property(p => p.UserAgentInfo).IsRequired(true);
                e.Property(p => p.UserId).IsRequired(true);
            });

            builder.Entity<Track>(e =>
            {
                e.HasKey(k => k.Id);
                e.Property(p => p.Title).IsRequired(true);
                e.Property(p => p.Description).IsRequired(false);
                e.Property(p => p.CreatedById).IsRequired(true);
            });
        }
    }
}
