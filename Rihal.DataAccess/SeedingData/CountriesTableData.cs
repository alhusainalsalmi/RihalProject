using Rihal.Domain.Entities;


namespace Rihal.DataAccess.SeedingData
{
    public class CountriesTableData
    {
        public static readonly List<Country> CountriesData = new List<Country>()
        {
            new Country(){CountryId=1, Name=Faker.Country.Name()},
            new Country(){CountryId=2, Name=Faker.Country.Name()},
            new Country(){CountryId=3,Name=Faker.Country.Name()}
        };
    }
}
