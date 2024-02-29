using Microsoft.AspNetCore.Identity;
using WeDriveRental.Models;

namespace WeDriveRental.Data
{
	// Add profile data for application users by adding properties to the ApplicationUser class
	public class ApplicationUser : IdentityUser
	{
		public List<Booking>? UserBookings { get; set; } = new List<Booking>();
	}

}
