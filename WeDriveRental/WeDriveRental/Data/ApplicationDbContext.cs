using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeDriveRental.Models;

namespace WeDriveRental.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<RentalCar> Cars { get; set; }
		public DbSet<Booking> Bookings { get; set; }


	}
}
