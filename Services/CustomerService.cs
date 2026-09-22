using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using TravelApi.Entities;
using TravelApi.Data;
using TravelApi.Dto;

namespace TravelApi.Services;

public interface ICustomerService
{
    Task<(Customer? Customer, string? Error)> RegisterAsync(RegisterRequest request);
    Task<Customer?> GetByIdAsync(Guid id);

    Task<string?> DeleteByIdAsync(Guid id);
}

public class CustomerService : ICustomerService
{
    readonly AppDbContext _db;

    static readonly Regex PasswordRule = new(@"^(?=.*[0-9])(?=.*[^A-Za-z0-9]).{8,}$");

    public CustomerService(AppDbContext db)
    {
        _db = db;

        Console.WriteLine(
            $"\u001b[32mCustomerService initialized with database context: {_db.Database.GetDbConnection().Database}\u001b[0m"
        );
    }

    public async Task<(Customer? Customer, string? Error)> RegisterAsync(RegisterRequest request)
    {
        if (!PasswordRule.IsMatch(request.Password))
            return (null, "Password must be at least 8 characters and include a number and a special character.");

        if (await _db.Customers.AnyAsync(c => c.Email == request.Email))
            return (null, "Email already registered.");

        if (await _db.Customers.AnyAsync(c => c.Username == request.Username))
            return (null, "Username already taken.");

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Nationality = "",
            Disabilty = false,
            SecurityConcerns = false
        };

        _db.Customers.Add(customer);
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