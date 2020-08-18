using Data.UrlShortner;
using Microsoft.EntityFrameworkCore;

namespace Repo.UrlShorner
{
    public class UrlShortnerContext : DbContext
    {
        public DbSet<UrlData> UrlDatas { get; set; }

        public UrlShortnerContext(DbContextOptions<UrlShortnerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlData>().Property(x => x.Id).HasDefaultValueSql("newid()");
            modelBuilder.Entity<UrlData>().HasIndex(x => x.ShortenedURL).IsUnique();
            modelBuilder.Entity<UrlData>().HasIndex(x => x.Token).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
