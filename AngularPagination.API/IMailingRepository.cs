using AngularPagination.API.Models;

namespace AngularPagination.API
{
    public interface IMailingRepository
    {
        PagedList<Recipient> GetUsers(RecipientParams recipientParams);
    }
}