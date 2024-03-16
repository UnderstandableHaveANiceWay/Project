using ProjectV2.Domain.Utils.Enums;

namespace ProjectV2.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; } = null!;
    }
}
