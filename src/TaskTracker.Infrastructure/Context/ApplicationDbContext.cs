using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Entities;

namespace TaskTracker.Infrastructure.Context;

internal sealed class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<ProcessEntity> Processes { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<RemarkEntity> Remarks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ProcessEntity>()
            .HasOne(p => p.Admin)
            .WithMany(u => u.Processes)
            .HasForeignKey(p => p.AdminId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ProcessEntity>()
            .HasMany(p => p.Tasks)
            .WithOne(t => t.Process)
            .HasForeignKey(t => t.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProcessEntity>()
            .HasMany(p => p.Tags)
            .WithOne(t => t.Process)
            .HasForeignKey(t => t.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TaskEntity>()
            .HasOne(t => t.CreatedBy)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<TaskEntity>()
            .HasOne(t => t.AssignedTo)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(t => t.AssignedToId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<TaskEntity>()
            .HasOne(t => t.Process)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TaskEntity>()
            .HasMany(t => t.Remarks)
            .WithOne(r => r.Task)
            .HasForeignKey(r => r.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<TaskEntity>()
            .HasMany(t => t.Tags)
            .WithMany(tag => tag.Tasks);

        builder.Entity<UserEntity>()
            .HasMany(u => u.Remarks)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<TagEntity>()
            .HasOne(t => t.Process)
            .WithMany(p => p.Tags)
            .HasForeignKey(t => t.ProcessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RemarkEntity>()
            .HasOne(r => r.Task)
            .WithMany(t => t.Remarks)
            .HasForeignKey(r => r.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RemarkEntity>()
            .HasOne(r => r.User)
            .WithMany(u => u.Remarks)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
