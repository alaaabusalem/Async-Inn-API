﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interfaces;
using Async_Inn.Models.DTOs;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
		private readonly IHotel _hotel;


		public HotelsController(IHotel hotel)
		{
			_hotel = hotel;
		}

		// GET: api/Hotels
		[HttpGet]
		public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
		{
			var hotels = await _hotel.GetHotels();
			if (hotels == null)
			{
				return NotFound();
			}
			return hotels;
		}

		// GET: api/Hotels/5
		[HttpGet("{id}")]
		public async Task<ActionResult<HotelDTO>> GetHotel(int id)
		{
			var hotel = await _hotel.GetHotel(id);
			if (hotel == null)
			{
				return NotFound();
			}

			return hotel;
		}

		// PUT: api/Hotels/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutHotel(int id, HotelDTO hotelDTO)
		{

			if (id != hotelDTO.ID)
			{
				return BadRequest();
			}
			var updatedHotelDTO = await _hotel.UpdateHotel(id, hotelDTO);
			return Ok(updatedHotelDTO);


		}

		// POST: api/Hotels
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
		{
			await _hotel.Create(hotel);

			// Rurtn a 201 Header to Browser or the postmane
			return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
		}

		// DELETE: api/Hotels/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteHotel(int id)
		{
			await _hotel.Delete(id);

			return NoContent();
		}



	}
}
