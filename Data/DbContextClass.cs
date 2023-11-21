using forum.Dtos;
using forum.Entities;
using forum.Models;
using Microsoft.EntityFrameworkCore;

namespace forum.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<MainForum> mainForums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ForumSubscription> forumSubs { get; set; }
        public virtual DbSet<Post> Post { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add your model configurations here if needed.
        }
    }
}
