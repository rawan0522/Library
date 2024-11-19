namespace Library.DTOs.BookDTO
{
    public class BookOnly
    {
        public string? Title { get; set; }
        public DateTime publishedyear { get; set; }
        public List<int>? AuthorID { get; set; }
        public List<int>? GenerID { get; set; }
    }
}
