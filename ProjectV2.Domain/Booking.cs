using ProjectV2.Domain.Utils.Enums;

namespace ProjectV2.Domain
{
    public class Booking : BaseEntity
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public BookingStatus Status { get; set; }
        public string Notes { get; set; } = string.Empty;
        public string BookedFor { get; set; } = string.Empty;
        public virtual User User { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<BookingAudit> BookingAudits { get; set; } = null!;
    }
}
