using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _context;

        public CustomerFeatures(MovieRentalDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> GetById(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}