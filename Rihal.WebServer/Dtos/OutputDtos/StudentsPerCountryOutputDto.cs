using Rihal.Domain.ValueObjects;

namespace Rihal.WebServer.Dtos.OutputDtos
{
    public class StudentsPerCountryOutputDto
    {
        public string CountryName { get; set; }
        public int NumberOfStudents { get; set; }

        public static StudentsPerCountryOutputDto Map(StudentsPerCountry studentsPerCountry)
        {
            return new StudentsPerCountryOutputDto
            {
                CountryName = studentsPerCountry.CountryName,
                NumberOfStudents = studentsPerCountry.NumberOfStudents
            };
        }
    }
}
