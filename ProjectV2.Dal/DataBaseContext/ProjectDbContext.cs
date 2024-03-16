using Microsoft.EntityFrameworkCore;
using ProjectV2.Dal.EntityConfigurations;
using ProjectV2.Domain;

namespace ProjectV2.Dal.DataBaseContext
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BookingAudit> BookingAudits { get; set; } = null!;
        public DbSet<RoomType> RoomTypes { get; set; } = null!;
        public DbSet<Floor> Floors { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<RoomImage> RoomImages { get; set; } = null!;

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
