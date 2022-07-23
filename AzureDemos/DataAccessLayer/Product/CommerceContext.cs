using DomainLayer;
using DomainLayer.Prdct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Prdct     
{
    public class CommerceContext : DbContext
    {
        private readonly string connectionString;
        public CommerceContext(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentException(
            "connectionString should not be empty.", "connectionString");

            this.connectionString = connectionString;
        }

        // Uses CONSTRUCTOR INJECTION on the required DEPENDENCIES; in this case, connectionString
        // The DEPENDENCY is stored and used later in the OnConfiguring method to set up the CommerceContext for use.

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(connectionString);
        }
    }

}
