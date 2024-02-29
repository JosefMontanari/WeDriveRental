using WeDriveRental.Data;

namespace WeDriveRental.Models
{
	public class Booking
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int UserId { get; set; }
		public ApplicationUser BookedUser { get; set; } = null!;
		public int CarId { get; set; }
		public RentalCar BookedCar { get; set; } = null!;
	}
}
