using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Api.Context
{
    public class MyTaskContext : DbContext
    {
        public MyTaskContext(DbContextOptions<MyTaskContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            Database.EnsureCreated();
        }

        public DbSet<MyTask> Tasks { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /* modelBuilder.Entity<Desenvolvedor>()
            .HasOne<MyTask>(d => d.Task)
            .WithOne(t => t.Desenvolvedor)
            .HasForeignKey<MyTask>(t => t.DesenvolvedorId); */
        }  
    } 
    
}