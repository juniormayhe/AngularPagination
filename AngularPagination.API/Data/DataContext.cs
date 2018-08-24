using System.Collections.Generic;
using AngularPagination.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularPagination.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Recipient> Recipients {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
            modelBuilder.ApplyConfiguration(new RecipientEntityTypeConfiguration());;
            
            base.OnModelCreating(modelBuilder);
        }
    }
}