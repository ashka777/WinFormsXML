using Microsoft.EntityFrameworkCore;

namespace WinFormsXML.Models
{
    public class ClientsContext : DbContext
    {
        public DbSet<Clients> Client { get; set; }

        public DbSet<LogMessages> LogMessage { get; set; }

        public ClientsContext()
        {
            var resBool = Database.EnsureCreated();// Async();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ClientDB;Trusted_Connection=True;");
        }
    }
}