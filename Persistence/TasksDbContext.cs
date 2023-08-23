using System;
using Microsoft.EntityFrameworkCore;



namespace TasksAPI.Persistence
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options) : base(options)
        { }


        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Task>(o =>
            {

                o.HasKey(j => j.Id);
            });

        }
    }

}