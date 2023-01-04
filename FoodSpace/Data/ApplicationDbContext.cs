using FoodSpace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FoodSpace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }

        public DbSet<Recipe> Recipe { get; set; }
        
        public DbSet<ItemRecipe> ItemRecipe { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<ItemRecipe>()
                .HasKey(x => new { x.ItemRecipeId } );

            builder.Entity<ItemRecipe>()
                .HasOne(x => x.Item)
                .WithMany(x => x.ItemRecipe)
                .HasForeignKey(x => x.ItemId);

            builder.Entity<ItemRecipe>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.ItemRecipe)
                .HasForeignKey(x => x.RecipeId);
        }
    }
}