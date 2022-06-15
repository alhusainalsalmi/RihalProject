using Microsoft.EntityFrameworkCore;
using Rihal.DataAccess.DbContext;
using Rihal.DataAccess.Repositories;
using Rihal.DataAccess.SeedingData;


namespace Rihal.Test.Repositories
{
    public class StudentsRepositoryTestSuccess
    {
        private DbContextOptions<RihalDbContext> dbContextOptions;

        public StudentsRepositoryTestSuccess()
        {
            var dbName = $"RihalProjectDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<RihalDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetCountStudentsPerClass_ListHasItems_ListHasThreeItems()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            // Act
            var result = await studentRepository.GetCountStudentsPerClass();

            // Assert
            Assert.Equal(ClassesTableData.ClassesData.Count(), result.Count);
        }
      

        [Fact]
        public async Task GetCountStudentsPerCountry_ListHasItems_ListHasThreeItems()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            // Act
            var result = await studentRepository.GetCountStudentsPerCountry();

            // Assert
            Assert.Equal(CountriesTableData.CountriesData.Count(), result.Count);
        }


        [Fact]
        public async Task GetStudentsDateOfBirth_ListHasItems_ListHasEightItems()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            // Act
            var result = await studentRepository.GetStudentsDateOfBirth();

            // Assert
            Assert.Equal(StudentsTableData.StudentsData.Count(), result.Count);
        }

        private async Task<StudentRepository> CreateRepository()
        {
            RihalDbContext context = new RihalDbContext(dbContextOptions);
            await PopulateData(context);
            return new StudentRepository(context);
        }

        private async Task PopulateData(RihalDbContext context)
        {
            await context.Classes.AddRangeAsync(ClassesTableData.ClassesData);
            await context.Countries.AddRangeAsync(CountriesTableData.CountriesData);
            await context.Students.AddRangeAsync(StudentsTableData.StudentsData);

            await context.SaveChangesAsync();
        }
    }
}
