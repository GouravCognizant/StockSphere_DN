namespace StockSphere_DN.Models.DTOs
{
    public class SignUpRequest
    {
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty; 
        public string? Role { get; set; } = "User";
    }
}
