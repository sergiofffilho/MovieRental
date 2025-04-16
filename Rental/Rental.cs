﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRental.Rental
{
	public class Rental
	{
		[Key]
		public int Id { get; set; }
		public int DaysRented { get; set; }
		public Movie.Movie? Movie { get; set; }
		public Customer.Customer? Customer { get; set; }

		[ForeignKey("Movie")]
		public int MovieId { get; set; }

		// TODO: we should have a table for the customers -> DONE
		[ForeignKey("Customer")]
		public int CustomerId { get; set; }
	}
}
