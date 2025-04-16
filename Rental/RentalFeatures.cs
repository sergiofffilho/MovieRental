﻿using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		//TODO: make me async :( - DONE
		public async Task<Rental> Save(Rental rental)
		{
			_movieRentalDb.Rentals.Add(rental);
			await _movieRentalDb.SaveChangesAsync();
			return rental;
		}

		//TODO: finish this method and create an endpoint for it - DONE
		public async Task<IEnumerable<Rental>> GetRentalsByCustomerName(string customerName)
		{
			return await _movieRentalDb.Rentals
            .Where(rental => rental.CustomerName.ToLower().Contains(customerName.ToLower()))
            .ToListAsync();
		}
	}
}
