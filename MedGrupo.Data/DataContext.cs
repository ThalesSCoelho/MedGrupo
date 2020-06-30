using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MedGrupo.Domain;

namespace MedGrupo.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Contato> Contato { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }               
        
    } 

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext> 
    { 
        public DataContext CreateDbContext(string[] args) 
        { 
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "../appsettings.json")
                .Build(); 
            var builder = new DbContextOptionsBuilder<DataContext>(); 
            var connectionString = configuration.GetConnectionString("DefaultConnection"); 
            builder.UseSqlServer(connectionString); 
            return new DataContext(builder.Options); 
        } 
    }   
}