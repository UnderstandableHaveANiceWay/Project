using ProjectV2.Domain.Utils.Enums;

namespace ProjectV2.Domain
{
    public class BookingAudit : BaseEntity
    {
        public BookingStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public virtual User User { get; set; } = null!;
        public string? Notes { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; } = null!;
    }
}
