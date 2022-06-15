using Rihal.Domain.Entities;


namespace Rihal.DataAccess.SeedingData
{
    public class StudentsTableData
    {
        private static readonly int maxNumber = 100;

        public static readonly List<Student> StudentsData = new List<Student>()
        {
            new Student(){StudentId=1,Name=Faker.Name.FullName(),CountryId=1,ClassId=1,DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=2,Name=Faker.Name.FullName(),CountryId=2,ClassId=1, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=3,Name=Faker.Name.FullName(),CountryId=3,ClassId=1, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=4,Name=Faker.Name.FullName(),CountryId=3,ClassId=2, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=5,Name=Faker.Name.FullName(),CountryId=3,ClassId=2, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=6,Name=Faker.Name.FullName(),CountryId=1,ClassId=3, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=7,Name=Faker.Name.FullName(),CountryId=1,ClassId=3, DateOfBirth= Faker.Identification.DateOfBirth()},
            new Student(){StudentId=8,Name=Faker.Name.FullName(),CountryId=2,ClassId=3, DateOfBirth= Faker.Identification.DateOfBirth()},
        };
    }
}
