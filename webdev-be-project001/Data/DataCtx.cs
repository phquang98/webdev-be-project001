using Microsoft.EntityFrameworkCore;
using webdev_be_project001.Models;

namespace webdev_be_project001.Data
{
    public class DataCtx : DbContext
    {
        public DataCtx(DbContextOptions<DataCtx> options)
            : base(options) { }

        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Country> CountryTable { get; set; }
        public DbSet<Owner> OwnerTable { get; set; }
        public DbSet<Pokemon> PokemonTable { get; set; }
        public DbSet<JoinPokemonOwner> PokemonOwnerTable { get; set; }
        public DbSet<JoinPokemonCategory> PokemonCategoryTable { get; set; }
        public DbSet<Review> ReviewTable { get; set; }
        public DbSet<Reviewer> ReviewerTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<JoinPokemonCategory>()
                .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder
                .Entity<JoinPokemonCategory>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonCategoryClt)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder
                .Entity<JoinPokemonCategory>()
                .HasOne(p => p.Category)
                .WithMany(pc => pc.PokemonCategoryClt)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<JoinPokemonOwner>().HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder
                .Entity<JoinPokemonOwner>()
                .HasOne(p => p.Pokemon)
                .WithMany(pc => pc.PokemonOwnerClt)
                .HasForeignKey(p => p.PokemonId);
            modelBuilder
                .Entity<JoinPokemonOwner>()
                .HasOne(p => p.Owner)
                .WithMany(pc => pc.PokemonOwnerClt)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}
