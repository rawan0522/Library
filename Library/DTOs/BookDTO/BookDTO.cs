using Library.DTOs.AutherDTO;
using Library.DTOs.GenerDTO;


    public class BookDTO
    {
        public string? Title { get; set; }
        public DateTime publishedyear { get; set; }
        public List<AutherDTO>? Authers { get; set; }
        public List<GenerDTO>? Generers { get; set; }
    }

