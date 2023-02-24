namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<Login> Logins { get; set; }
    }
}
