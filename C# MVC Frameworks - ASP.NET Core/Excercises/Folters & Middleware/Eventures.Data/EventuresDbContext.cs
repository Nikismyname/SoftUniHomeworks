namespace Eventures.Data
{
    using Eventures.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EventuresDbContext : IdentityDbContext<User>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }


        public DbSet<Event> Events { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
