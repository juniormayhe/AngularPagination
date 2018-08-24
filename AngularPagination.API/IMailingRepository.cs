using System.Collections.Generic;
using AngularPagination.API.Models;

namespace AngularPagination.API
{
    public interface IMailingRepository
    {
        List<Recipient> GetUsers(RecipientParams recipientParams);
    }
}