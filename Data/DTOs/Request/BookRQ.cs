namespace DataAccess.DTOs.Request
{
    public class BookRQ
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public int PageNumber { get; set; }
        public int EditorialId { get; set; }
        public int AuthorId { get; set; }
    }
}
