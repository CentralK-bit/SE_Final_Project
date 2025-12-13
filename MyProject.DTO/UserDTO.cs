namespace MyProject.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Role { get; set; }
    }
}