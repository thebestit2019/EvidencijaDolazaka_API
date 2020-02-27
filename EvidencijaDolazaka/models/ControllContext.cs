using Microsoft.EntityFrameworkCore;
using System;


namespace EvidencijaDolazaka.models{

    public class ControllContext : DbContext{
        // public ControllContext(DbContextOptions<ControllContext> options)
        // : base(options) {}

        public DbSet<Employee> employee {get; set;}
        public DbSet<Time> time {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=192.168.0.122;Database=projekat;Username=postgres;Password=pangler234");
    }

    
}