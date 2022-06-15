using FluentAssertions;
using Moq;
using Rihal.Domain.Repositories;
using Rihal.Domain.ValueObjects;
using Rihal.WebServer.Dtos.OutputDtos;
using Rihal.WebServer.Services;

namespace Rihal.Test.Services
{
    public class StudentServiceTest
    {
        private readonly Mock<IStudentRepository> studentsRepository = new();

        [Fact]
        public async Task GetStudentsStatistics_ListHasItems_ReturnStudentsStatisticsOutputDto()
        {
            //Arrange
            var ExpectedStudentsPerClassList = CreateStudentsPerClassList();

            var ExpectedStudentsPerCountryList = CreateStudentsPerCountryList();

            var ExpectedStudentsDateOfBirthList = CreateStudentsDateOfBirthList();

            var ExpectedStudentsStatisticsOutputDto = CreateStudentsStatisticsOutputDto();


            studentsRepository.Setup(repository => repository.GetCountStudentsPerClass())
                .Returns(ExpectedStudentsPerClassList);

            studentsRepository.Setup(repository => repository.GetCountStudentsPerCountry())
                .Returns(ExpectedStudentsPerCountryList);

            studentsRepository.Setup(repository => repository.GetStudentsDateOfBirth())
                .Returns(ExpectedStudentsDateOfBirthList);

            var service = new StudentService(studentsRepository.Object);

            //Act

            var result = await service.GetStudentsStatistics();

            //Assert

            result.Should().BeEquivalentTo(ExpectedStudentsPerClassList,
                options => options.ComparingByMembers<StudentsPerClassOutputDto>().ExcludingMissingMembers());

            result.Should().BeEquivalentTo(ExpectedStudentsPerCountryList,
                options => options.ComparingByMembers<StudentsPerCountryOutputDto>().ExcludingMissingMembers());

            result.Should().BeEquivalentTo(ExpectedStudentsDateOfBirthList,
                options => options.ComparingByMembers<DateTime>().ExcludingMissingMembers());

            result.Should().BeEquivalentTo(ExpectedStudentsStatisticsOutputDto,
                options => options.ComparingByMembers<StudentsStatisticsOutputDto>().ExcludingMissingMembers());
        }

        private Task<List<StudentsPerClass>> CreateStudentsPerClassList()
        {
            var output = new List<StudentsPerClass>() 
            {
                 new StudentsPerClass{ClassName="Comp102",NumberOfStudents=50},
                 new StudentsPerClass{ClassName="Comp103",NumberOfStudents=60},
            };

          

            return Task.FromResult(output);
        }
        private Task<List<StudentsPerCountry>> CreateStudentsPerCountryList()
        {
            var output = new List<StudentsPerCountry>()
            {
               new StudentsPerCountry { CountryName = "Oman", NumberOfStudents = 20 },
               new StudentsPerCountry { CountryName = "UK", NumberOfStudents = 30 },
            };



            return Task.FromResult(output);
        }
        private Task<List<DateTime>> CreateStudentsDateOfBirthList()
        {
            var output = new List<DateTime>()
            {
                new DateTime(),
                new DateTime(),
            };

           

            return Task.FromResult(output);
        }

        private StudentsStatisticsOutputDto CreateStudentsStatisticsOutputDto()
        {
            return new StudentsStatisticsOutputDto()
            {
                AverageStudentsAge = 2021,
                 StudentsPerClass= CreateStudentsPerClassOutputDto(),
                StudentsPerCountry = CreateStudentsPerCountryOutputDto()

            };

        }

        private List<StudentsPerClassOutputDto> CreateStudentsPerClassOutputDto()
        {
            var output = new List<StudentsPerClassOutputDto>() 
            {
               new StudentsPerClassOutputDto{ClassName="Comp102",NumberOfStudents=50},
               new StudentsPerClassOutputDto{ClassName="Comp103",NumberOfStudents=60},

            };
          

            return output;
        }
        private List<StudentsPerCountryOutputDto> CreateStudentsPerCountryOutputDto()
        {
            var output = new List<StudentsPerCountryOutputDto>()
            {
               new StudentsPerCountryOutputDto{CountryName="Oman",NumberOfStudents=20},
               new StudentsPerCountryOutputDto{CountryName="UK",NumberOfStudents=30},

            };

            return output;
        }
    }
}
