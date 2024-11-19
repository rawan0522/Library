namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ?Title { get; set; }
        public DateTime PublishedYear { get; set; }
        public ICollection<Author> ?Author { get; set; }
        public ICollection<Genere> ?Generes { get; set; }
    }
}
