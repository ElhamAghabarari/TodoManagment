

using Microsoft.EntityFrameworkCore;
using TodoManagment.Domain;

namespace TodoManagment.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<TodoTask> tasks { get; set; }
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(t => t.Id);
                entity.HasMany(t => t.Tasks).WithOne(t => t.User);

                entity.Property(t => t.Id).ValueGeneratedOnAdd(); 
                entity.Property(t => t.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.LastName).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<TodoTask>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(t => t.Id);
                entity.HasOne(t => t.User).WithMany(x => x.Tasks).HasForeignKey(t => t.UserId);

                entity.Property(t => t.Id).ValueGeneratedOnAdd();
                entity.Property(t => t.Title).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Description).HasMaxLength(500);
                entity.Property(t => t.createTime).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(t => t.Status).HasDefaultValue(TaskStatusEnum.TASK_OPEN);
            }); 
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
