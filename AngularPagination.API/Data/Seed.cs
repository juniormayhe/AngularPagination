using System.Collections.Generic;
using System.Linq;
using AngularPagination.API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AngularPagination.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedRecipients(){
             //_context.Users.RemoveRange(_context.Users);
             //_context.SaveChanges();
            if (_context.Recipients.Any())
                return;
                
                
            //deserialize json to list
            var jsonData = System.IO.File.ReadAllText("Data/recipients.json");
            var recipients = JsonConvert.DeserializeObject<List<Recipient>>(jsonData);

            //add data
            _context.Database.BeginTransaction();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Recipients ON");
            _context.Recipients.AddRange(recipients);
            _context.SaveChanges();
            _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Recipients OFF");
            _context.Database.CommitTransaction();
        }        
        
    }
}