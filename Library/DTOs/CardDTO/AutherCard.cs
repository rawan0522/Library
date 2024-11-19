using Library.Models;

namespace Library.DTOs.CardDTO
{
    public class AutherCard
    {
        public string? Name { get; set; }
        public string? credetCard { get; set; }
        public Author ?Author { get; set; }
    }
}
