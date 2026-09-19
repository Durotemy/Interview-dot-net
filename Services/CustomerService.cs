using Microsoft.EntityFrameworkCore;
using TravelApi.Entities;
using TravelApi.Data;
using Microsoft.AspNetCore.Http.HttpResults;

namespace TravelApi.Services;

public interface ICustomerService
{
    Task<(Customer? Customer, string? Error)> RegisterAsync(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);

    Task<string?> DeleteByIdAsync(Guid id);
}

public class CustomerService : ICustomerService
{
    readonly AppDbContext _db;

    public CustomerService(AppDbContext db)
    {
        _db = db;

        Console.WriteLine(
            $"\u001b[32mCustomerService initialized with database context: {_db.Database.GetDbConnection().Database}\u001b[0m"
        );
    }

    public async Task<(Customer? Customer, string? Error)> RegisterAsync(Customer customer)
    {
        var emailTaken = await _db.Customers.AnyAsync(c => c.Email == customer.Email);
        if (emailTaken)
            return (null, "Email already registered.");

        customer.Id = Guid.NewGuid();
        _db.Customers.Add(customer);
        Console.WriteLine(
    $"\u001b[31mCustomer registered: {customer.FirstName} {customer.LastName}, Email: {customer.Email}\u001b[0m"
);
        // Console.WriteLine($"Customer registered: {customer.FirstName} {customer.LastName}, Email: {customer.Email}");
        await _db.SaveChangesAsync();
        return (customer, null);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<string?> DeleteByIdAsync(Guid id)
    {
        var customer = await _db.Customers.FirstOrDefaultAsync(c => c.Id == id);

        if (customer is null)
        {
            return null;
        }
        _db.Customers.Remove(customer);
        await _db.SaveChangesAsync();
        return $"{customer.FirstName} deleted.";
    }
}
