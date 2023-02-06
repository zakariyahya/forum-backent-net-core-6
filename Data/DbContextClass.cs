using forum.Entities;
using forum.Models;
using Microsoft.EntityFrameworkCore;

namespace forum.Data
{
    public class DbContextClass: DbContext {
        protected readonly IConfiguration Configuration;
        public DbContextClass(IConfiguration configuration) {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseNpgsql(Configuration.GetConnectionString("ForumConnString"));
        }
        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<Forum> forums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}