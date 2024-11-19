namespace Library.Models
{
    public class Author
    {
       public int Id { get; set; }
       public string ?Name { get; set; }
       public string ?PhoneNumber { get; set; }
       public string ?Email { get; set; }
        public ICollection <Book>? Books { get; set; }
        public Card card { get; set; }
        public int CardId { get; set; }
        public Nationality Nationality { get; set; }
        public int NationalityID { get; set; }
    }
}
