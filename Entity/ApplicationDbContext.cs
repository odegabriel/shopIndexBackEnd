

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyProjectWithoutDocker.Model;

namespace MyProjectWithoutDocker.Entity
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<UserItemsModel>().HasKey(e => e.Id);
            modelBuilder.Entity<UserModel>().HasKey(e => e.Id);
            modelBuilder.Entity<ItemsModel>().HasKey(e => e.Id);

            modelBuilder.Entity<UserModel>().HasMany(e => e.Items)
                                            .WithOne(e => e.User)
                                            .HasForeignKey(e => e.UserId);
            
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<UserItemsModel> UserItemsModels { get; set; }
        public DbSet<ItemsModel> Items { get; set; }



    }
}
