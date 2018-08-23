namespace AngularPagination.API
{
    public class RecipientParams
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}