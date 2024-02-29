using WeDriveRental.Data;
using WeDriveRental.Models;

namespace WeDriveRental.Services
{
	public interface IRentalCarService
	{
		public List<RentalCar>? RentalCars { get; set; }
		public List<Booking>? Bookings { get; set; }

		public Task<List<Booking>> GetBookings();
		public Task<List<RentalCar?>> GetRentalCars();

		Task<Booking?> GetSingleBooking(int id);
		Task<RentalCar?> GetSingleRentalCar(int id);
		Task<bool> IsCarAvailable(int id, DateTime requestedDateStart, DateTime requestedDateEnd);
		Task<RentalCar> EditRentalCar(RentalCar car, int id);
		void DeleteRentalCar(int id);
		void AddRentalCar(RentalCar car);
		Task<ApplicationUser?> EditUser(ApplicationUser user, string id);
	}
}
