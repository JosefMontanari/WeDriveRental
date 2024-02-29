using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeDriveRental.Models;

namespace WeDriveRental.Data
{
	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
	{
		public DbSet<RentalCar> Cars { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<RentalCar>()
				.HasData(
				new RentalCar()
				{
					Id = 1,
					Name = "Mercedes E-Klass",
					Description = "E 220 d 194hk, AMG Pano Burmester Drag 360° Navi",
					Price = 1799,
					ImageUrl = "https://kvdbil-object-images.imgix.net/7178075/848243.jpg?w=1920&auto=format"

				},
				new RentalCar()
				{
					Id = 2,
					Name = "KIA Cee'd",
					Description = "XCeed Plug-in, Advance Plus B-kam",
					Price = 899,
					ImageUrl = "https://kvdbil-object-images.imgix.net/7191259/995776.jpg?w=1920&auto=format"

				},
				new RentalCar()
				{
					Id = 3,
					Name = "Volvo XC40",
					Description = "T2 129hk, Momentum Läder Teknikpak D-värm VOC",
					Price = 1199,
					ImageUrl = "https://kvdbil-object-images.imgix.net/7195428/c474c115.jpg?w=1920&auto=format"

				},
				new RentalCar()
				{
					Id = 4,
					Name = "Audi A3",
					Description = "Sportback 35 TFSI 150hk",
					Price = 999,
					ImageUrl = "https://kvdbil-object-images.imgix.net/7193409/953141.jpg?w=1920&auto=format"

				},
				new RentalCar()
				{
					Id = 5,
					Name = "BMW X7",
					Description = "xDrive40d, G07 (340hk+11hk), M Sport Innovation",
					Price = 2199,
					ImageUrl = "https://kvdbil-object-images.imgix.net/7194305/995071.jpg?w=1920&auto=format"

				}
				);
		}
	}
}
