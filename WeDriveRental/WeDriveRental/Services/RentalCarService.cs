using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using WeDriveRental.Data;
using WeDriveRental.Models;

namespace WeDriveRental.Services
{
	public class RentalCarService : IRentalCarService
	{
		public List<RentalCar>? RentalCars { get; set; }
		public List<Booking>? Bookings { get; set; }

		//private readonly HttpClient _httpClient; TODO lägg till en HttpClient för valutaväxling senare
		private readonly ApplicationDbContext _context;
		private readonly NavigationManager _navigationManager;

		public RentalCarService(NavigationManager navigationManager, ApplicationDbContext context)
		{
			_navigationManager = navigationManager;
			_context = context;

		}

		public async void AddRentalCar(RentalCar car)
		{
			if (car != null)
			{
				await _context.Cars.AddAsync(car);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Couldn't add car");
			}
		}

		public async void DeleteRentalCar(int id)
		{
			var dbCar = await _context.Cars
				.Include(x => x.CarBookings)
				.FirstOrDefaultAsync(h => h.Id == id);

			if (dbCar != null)
			{
				_context.Cars.Remove(dbCar);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Couldn't find that car, maybe it is already removed?");
			}

		}

		public async Task<RentalCar?> EditRentalCar(RentalCar car, int id)
		{
			var dbCar = await _context.Cars
				.Include(x => x.CarBookings)
				.FirstOrDefaultAsync(xx => xx.Id == id);
			if (dbCar != null)
			{
				dbCar.Price = car.Price;
				dbCar.Description = car.Description;
				dbCar.Name = car.Name;
				dbCar.CarBookings = car.CarBookings;
				await _context.SaveChangesAsync();
				return car;
			}
			return null;
		}

		public async Task<ApplicationUser?> EditUser(ApplicationUser user, string id)
		{
			var dbUser = await _context.Users
				.Include(x => x.UserBookings)
				.FirstOrDefaultAsync(xx => xx.Id == id);
			if (dbUser != null)
			{
				dbUser.UserName = user.UserName;
				dbUser.UserBookings = user.UserBookings;
				dbUser.PhoneNumber = user.PhoneNumber;
				dbUser.Email = user.Email;
				await _context.SaveChangesAsync();
				return user;
			}
			return null;
		}

		public async Task<List<Booking?>> GetBookings()
		{
			Bookings = await _context.Bookings
				.Include(x => new { x.BookedUser, x.BookedCar })
				.ToListAsync();
			if (Bookings != null)
			{
				return Bookings;
			}
			return null;
		}

		public async Task<List<RentalCar?>> GetRentalCars()
		{
			RentalCars = await _context.Cars
				.Include(x => x.CarBookings)
				.ToListAsync();
			if (RentalCars != null)
			{
				return RentalCars;
			}
			return null;
		}

		public async Task<Booking?> GetSingleBooking(int id)
		{
			Booking? booking = await _context.Bookings
				.Include(x => x.BookedCar)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (booking == null)
			{
				return null;
			}

			return booking;
		}

		public async Task<RentalCar?> GetSingleRentalCar(int id)
		{
			RentalCar? car = await _context.Cars
				.Include(x => x.CarBookings)
				.FirstOrDefaultAsync(x => x.Id == id);
			if (car == null)
			{
				return null;
			}

			return car;
		}

		public async Task<bool> IsCarAvailable(int id, DateTime requestedDateStart, DateTime requestedDateEnd)
		{
			bool isAvailable = true;
			RentalCar? car = await _context.Cars
				.Include(x => x.CarBookings)
				.FirstOrDefaultAsync(_context => _context.Id == id);
			if (car == null)
			{
				throw new Exception("Couldn't find that car");
			}
			List<Booking>? carBookings = car.CarBookings;

			if (carBookings == null)
			{
				return isAvailable;

			}
			else
			{

				foreach (var booking in carBookings)
				{
					// Kolla om det begärda datumintervallet kolliderar med någon befintlig bokning
					if ((requestedDateStart >= booking.StartDate && requestedDateStart < booking.EndDate) ||
						(requestedDateEnd > booking.StartDate && requestedDateEnd <= booking.EndDate) ||
						(requestedDateStart <= booking.StartDate && requestedDateEnd >= booking.EndDate))
					{
						isAvailable = false;
						break; // Om en kollision hittas, bryt loopen och returnera direkt
					}

				}

			}
			return isAvailable;
		}
	}
}
