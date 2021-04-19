using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DataLayer.Entities;


namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {}

        public DbSet<Directory> Directories { get; set; }
        public DbSet<Material> Materials{ get; set; }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var opttionBuilder = new DbContextOptionsBuilder<EFDBContext>();
            opttionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DLS_db;Trusted_Connection=True;MultipleActiveResultSets=True",
                    b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(opttionBuilder.Options);
        }
    }
}
