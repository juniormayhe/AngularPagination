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

        protected override void OnModelCreating(ModelBuilder builder) {
            //combination of fields for primary key because users cannot like more than one time another user
            builder.Entity<Recipient>()
                .HasKey(k => k.RecipientId);
        }
    }
}