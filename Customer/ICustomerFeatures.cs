namespace MovieRental.Customer
{
    public interface ICustomerFeatures
    {
        Task<Customer> Create(Customer customer);
        Task<Customer?> GetById(int id);
    }
}