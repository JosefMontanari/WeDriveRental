﻿namespace WeDriveRental.Models
{
	public class RentalCar
	{
		public int Id { get; set; }
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		public decimal Price { get; set; }
		public string? ImageUrl { get; set; }
		public List<DateTime>? BookedDates { get; set; }
		public bool IsAvailable { get; set; }
	}
}
