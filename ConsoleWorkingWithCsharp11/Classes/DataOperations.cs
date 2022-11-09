using Microsoft.EntityFrameworkCore;
using static ConsoleWorkingWithCsharp11.Classes.GenericSorterExtension;

namespace ConsoleWorkingWithCsharp11.Classes;

internal class DataOperations
{
    public static async Task<List<Customer>> ReadCustomersAsync()
    {
        await using var context = new Context();
        return await context.Customer
            .Include(x => x.ContactTypeNavigation)
            .Include(x => x.GenderNavigation)
            .ToListAsync();
    }

    public static async Task<List<Customer>> ReadCustomersGenericString()
    {
        await using var context = new Context();
        return await context.Customer.SortColumn(nameof(Customer.CompanyName),
                SortDirection.Descending)
            .ToListAsync();
    }
}