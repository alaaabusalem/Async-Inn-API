﻿using Async_Inn.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
	public class AsyncInnDbContext:IdentityDbContext<User>
	{
        public AsyncInnDbContext(DbContextOptions options) :base(options)
        {
            
        }
        public DbSet<Hotel> Hotels { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Amenity> Amenities { get; set; }
		public DbSet<RoomAmenity> RoomAmenities { get; set; }
		public DbSet<HotelRoom> HotelRooms { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Hotel>().HasData(
					new Hotel() { Id = 1, Name = "Async Inn Amman", City = "Amman", Country = "Jordan", StreetAddress = " 12-12-12", State = "Amman", Phone = "12345" },
			new Hotel() { Id = 2, Name = "Async Inn Aqaba", City = "Aqaba", Country = "Jordan", StreetAddress = " 13-13-13", State = "Aqaba", Phone = "67890" },
			new Hotel() { Id = 3, Name = "Async Inn Irbid", City = "Irbid", Country = "Jordan", StreetAddress = " 14-14-14", State = "Irbid", Phone = "56437" }
				);
			modelBuilder.Entity<Room>().HasData(
				new Room() {Id=1, Name= "Royalty" },
				new Room() { Id = 2, Name = "Golden" },
				new Room() { Id = 3, Name = "Silver" }
				);

			modelBuilder.Entity<Amenity>().HasData(
				new Amenity() { Id = 1, Name = "Coffee Maker" },
				new Amenity() { Id = 2, Name = "Overlooking the sea" },
				new Amenity() { Id = 3, Name = "Air Conditioner" }
				);

			modelBuilder.Entity<RoomAmenity>()
				.HasKey(roomaminity=> new{roomaminity.RoomId, roomaminity.AmenityId}
				); 

			modelBuilder.Entity<HotelRoom>()
				.HasKey(roomaminity => new { roomaminity.RoomNumber, roomaminity.HotelId }
				);
		}
	}
}
