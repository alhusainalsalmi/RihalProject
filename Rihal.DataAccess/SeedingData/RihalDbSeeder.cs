using Rihal.DataAccess.DbContext;

namespace Rihal.DataAccess.SeedingData
{
    public class RihalDbSeeder
    {
        public static void SeedRihalDb(RihalDbContext rihalDbContext)
        {
            if (!rihalDbContext.Students.Any())
            {

                rihalDbContext.Classes.AddRange(ClassesTableData.ClassesData);
                rihalDbContext.Countries.AddRange(CountriesTableData.CountriesData);
                rihalDbContext.Students.AddRange(StudentsTableData.StudentsData);

                rihalDbContext.SaveChanges();
            }
        }
    }
}
