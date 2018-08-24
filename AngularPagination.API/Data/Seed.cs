using System.Collections.Generic;
using System.Linq;
using AngularPagination.API.Models;
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
                
            var jsonData = System.IO.File.ReadAllText("Data/recipients.json");
            //deserialize json to list
            var recipients = JsonConvert.DeserializeObject<List<Recipient>>(jsonData);
            _context.Recipients.AddRange(recipients);

            _context.SaveChanges();
        }        
        
    }
}