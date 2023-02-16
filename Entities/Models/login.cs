namespace Entities.Models
{
    public class Login
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int Userid { get; set; }
        
        // Navigation Property
        public virtual User? User { get; set; }
    }
}
