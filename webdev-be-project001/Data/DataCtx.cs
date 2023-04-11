using Microsoft.EntityFrameworkCore;
using webdev_be_project001.Models;

namespace webdev_be_project001.Data
{
    public class DataCtx: DbContext
    {
        public DataCtx(DbContextOptions<DataCtx> options) : base(options)
        { 
            
        }

        public DbSet<Category> CategoryClt { get; set; }
        public DbSet<Country> CountryClt { get; set; }
        public DbSet<Owner> OwnerClt { get; set; }
        public DbSet<Pokemon> PokemonClt { get; set; }
        public DbSet<JoinPokemonOwner> PokemonOwnerClt { get; set; }
        public DbSet<JoinPokemonCategory> PokemonCategoryClt { get; set; }
        public DbSet<Review> ReviewClt { get; set; }
        public DbSet<Reviewer> ReviewerClt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JoinPokemonCategory>()
                    .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<JoinPokemonCategory>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<JoinPokemonCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<JoinPokemonOwner>()
                    .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<JoinPokemonOwner>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<JoinPokemonOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}
