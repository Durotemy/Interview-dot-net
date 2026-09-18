using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Data;

namespace TravelApi.Services;

public interface ICustomerService
{
    Task<(Customer? Customer, string? Error)> RegisterAsync(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);
}

public class CustomerService : ICustomerService
{
    readonly AppDbContext _db;

    public CustomerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<(Customer? Customer, string? Error)> RegisterAsync(Customer customer)
    {
        var emailTaken = await _db.Customers.AnyAsync(c => c.Email == customer.Email);
        if (emailTaken)
            return (null, "Email already registered.");

        customer.Id = Guid.NewGuid();
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
        return (customer, null);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }
}
