namespace Library.DTOs.AutherDTO
{
    public class AutherOnlyDto
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public List<int> ?BookID { get; set; }
    }
}

