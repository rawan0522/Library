namespace Library.Models
{
    public class Nationality
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public List<Author> authors { get; set; }

    }
}
