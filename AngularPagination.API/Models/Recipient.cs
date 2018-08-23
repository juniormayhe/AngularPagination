namespace AngularPagination.API.Models
{
    public class Recipient
    {
        public int RecipientId { get; set; }
        public string RecipientName { get; set; }
        public string Email { get; set; }
        public bool IsValid { get; set; }
        public bool Unsubscribe { get; set; }
    }
}