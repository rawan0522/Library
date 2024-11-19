namespace Library.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string ?creditnum { get; set; }

        public Author ?Author { get; set; }
       
    }
}
