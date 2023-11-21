using System.Collections.Generic;
using System.Linq;

namespace HtmlRendering.Model;

public class DataProvider
{
    private static readonly List<CustomerModel> customers;

    static DataProvider()
    {
        var faker = new Bogus.Faker<CustomerModel>()
            .RuleFor(c => c.Id, f => f.UniqueIndex)
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.BirthDate, f => f.Date.Past(60).AddYears(-20))
            .RuleFor(c => c.SpentAmount, f => f.Random.Decimal(100, 10000));
        customers = faker.Generate(200);
    }

    public static IQueryable<CustomerModel> GetSampleCustomersQueryable()
    {
        return customers.AsQueryable();
    }
}