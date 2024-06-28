public class User
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Role { get; set; } // Admin, User
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}