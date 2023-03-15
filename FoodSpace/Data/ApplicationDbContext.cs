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

        public DbSet<Step> Step { get; set; }

        public DbSet<Tag> Tag { get; set; }

        public DbSet <ItemTag> ItemTag { get; set; }

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

            builder.Entity<Step>()
               .HasKey(x => new { x.StepId });

            builder.Entity<Step>()
                .HasOne(x => x.Recipe)
                .WithMany(x => x.Steps)
                .HasForeignKey(x => x.RecipeId);

            builder.Entity<Tag>()
                .HasKey(x => x.TagId);


            builder.Entity<ItemTag>()
                .HasOne(x => x.Item)
                .WithMany(x => x.ItemTag)
                .HasForeignKey(x => x.ItemId);

            builder.Entity<ItemTag>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.ItemTags)
                .HasForeignKey(x => x.TagId);


        }
    }
}