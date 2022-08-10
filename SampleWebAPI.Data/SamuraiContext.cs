using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;

namespace SampleWebAPI.Data
{
    public class SamuraiContext : DbContext
    {

        public SamuraiContext(DbContextOptions<SamuraiContext> options):base(options)
        {

        }

        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<SamuraiBattleStat> SamuraiBattleStats { get; set; }
        public DbSet<Sword> Swords { get; set; }
        public DbSet<SwordType> SwordTypes { get; set; }
        public DbSet<AttrElement> AttrElements { get; set; }
        public DbSet<SwordElement> SwordElements { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>().HasMany(s => s.Battles)
                .WithMany(b => b.Samurais)
                .UsingEntity<BattleSamurai>(bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany()).Property(bs => bs.DateJoined)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SamuraiBattleStat>().HasNoKey().ToView("SamuraiBattleStats");

            modelBuilder.Entity<Sword>().HasMany(i => i.AttrElements)
                .WithMany(j => j.Swords)
                .UsingEntity<SwordElement>(se => se.HasOne<AttrElement>().WithMany(),
                se => se.HasOne<Sword>().WithMany()).Property(se => se.DateLog)
                .HasDefaultValueSql("getdate()");
        }
    }
}
