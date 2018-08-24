using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System;
using AngularPagination.API.Models;
using Microsoft.Extensions.Configuration;

namespace AngularPagination.API
{
    public class MailingRepository : IMailingRepository
    {
        public IConfiguration Configuration { get; }
        public MailingRepository(IConfiguration configuration)
        {
            this.Configuration = configuration;

        }
        private List<Recipient> getRecipients()
        {
            var data = System.IO.File.ReadAllText("Data/recipients.json");
            //deserialize json to list
            List<Recipient> list = JsonConvert.DeserializeObject<List<Recipient>>(data);
            return list;
        }


        public List<Recipient> GetUsers(RecipientParams recipientParams)
        {
            var recipients = new List<Recipient>();
            
            using (var cnn = new SqlConnection(this.Configuration["ConnectionStrings:DefaultConnection"]))
            {
                cnn.Open();
                //equivalent to EF Skip and Take? We should benchmark it 
                var cmd = new SqlCommand($@"SELECT recipientId, RecipientName, Email, IsValid, Unsubscribe
                                            FROM Recipients 
                                            ORDER BY {recipientParams.OrderBy}
                                            OFFSET     {(recipientParams.PageSize * (recipientParams.PageNumber -1))} ROWS 
                                            FETCH NEXT {recipientParams.PageSize} ROWS ONLY", cnn);
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var recipient = new Recipient
                        {
                            RecipientId = Convert.ToInt32(dr["RecipientId"]),
                            RecipientName = dr["RecipientName"] as string,
                            Email = dr["Email"] as string,
                            IsValid = Convert.ToBoolean(dr["IsValid"]),
                            Unsubscribe = Convert.ToBoolean(dr["Unsubscribe"])
                        };
                        recipients.Add(recipient);
                    }

                }
            }
            if (!string.IsNullOrEmpty(recipientParams.OrderBy))
            {
                switch (recipientParams.OrderBy)
                {
                    case "RecipientName":
                        recipients = recipients.OrderBy(u => u.RecipientName).ToList();
                        break;
                    default:
                        recipients = recipients.OrderBy(u => u.RecipientId).ToList();
                        break;
                }
            }
            return recipients;
        }

    }
}