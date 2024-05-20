using GraduationProjectAPI.Entities;
using Microsoft.EntityFrameworkCore;
namespace GraduationProjectAPI.DB
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<RoomChat> RoomChats { get; set;}
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewImage> ReviewImages {  get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageImage> MessagesImage { get; set; }
    }
}
