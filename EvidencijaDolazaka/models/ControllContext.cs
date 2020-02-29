using Microsoft.EntityFrameworkCore;
using System;


namespace EvidencijaDolazaka.models{

    public class ControllContext : DbContext{
        // public ControllContext(DbContextOptions<ControllContext> options)
        // : base(options) {}

        public DbSet<Employee> employee {get; set;}
        public DbSet<Time> time {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){

             optionsBuilder.UseNpgsql(@"Server=192.168.0.122;Port=5432;Database=projekat;User Id=postgres;Password=pangler234; ");
            base.OnConfiguring(optionsBuilder);

        }
    }

    
}