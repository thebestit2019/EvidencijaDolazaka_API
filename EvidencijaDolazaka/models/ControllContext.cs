using Microsoft.EntityFrameworkCore;


namespace EvidencijaDolazaka.models{

    public class ControllContext : DbContext{
        public ControllContext(DbContextOptions<ControllContext> options)
        : base(options) {}

        public DbSet<Employee> employee {get; set;}
        public DbSet<Time> time {get; set;}

    }
}