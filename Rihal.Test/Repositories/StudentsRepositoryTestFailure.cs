using Microsoft.EntityFrameworkCore;
using Rihal.DataAccess.DbContext;
using Rihal.DataAccess.Repositories;
using Rihal.Domain.Entities;
using Rihal.Domain.Exceptions;


namespace Rihal.Test.Repositories
{
    public  class StudentsRepositoryTestFailure
    {
        private DbContextOptions<RihalDbContext> dbContextOptions;

        public StudentsRepositoryTestFailure()
        {
            var dbName = $"rihalProjectDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<RihalDbContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public async Task GetCountStudentsPerClass_ListHasNoItems_ReturnRihalAppNullException()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            try
            {            //Act
                var result = await studentRepository.GetCountStudentsPerClass();
            }
            catch (RihalAppNullException ex)
            {
                // Assert
                Assert.Equal($"error in fetching CountStudentsPerClass {typeof(StudentRepository)} ", ex.Message);
            }

        }

        [Fact]
        public async Task GetCountStudentsPerCountry_ListHasItems_ListHasNoItems_ReturnRihalAppNullException()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            try
            {            //Act
                var result = await studentRepository.GetCountStudentsPerCountry();
            }
            catch (RihalAppNullException ex)
            {
                // Assert
                Assert.Equal($"error in fetching CountStudentsPerCountry {typeof(StudentRepository)}", ex.Message);
            }

        }

        [Fact]
        public async Task GetStudentsDateOfBirth_ListHasItems_ListHasNoItems_ReturnRihalAppNullException()
        {
            //Arrange
            var studentRepository = await CreateRepository();

            try
            {            //Act
                var result = await studentRepository.GetStudentsDateOfBirth();
            }
            catch (RihalAppNullException ex)
            {
                // Assert
                Assert.Equal($"error in fetching studentsDateOfBirth {typeof(StudentRepository)} ", ex.Message);
            }

        }


        private async Task<StudentRepository> CreateRepository()
        {
            RihalDbContext context = new RihalDbContext(dbContextOptions);
            await PopulateData(context);
            return new StudentRepository(context);
        }

        private async Task PopulateData(RihalDbContext context)
        {
            await context.Classes.AddRangeAsync(new List<Class>());
            await context.Countries.AddRangeAsync(new List<Country>());
            await context.Students.AddRangeAsync(new List<Student>());

            await context.SaveChangesAsync();
        }
    }
}
