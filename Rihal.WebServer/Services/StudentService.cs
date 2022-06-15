using Rihal.Domain.Exceptions;
using Rihal.Domain.Repositories;
using Rihal.WebServer.Dtos.OutputDtos;
using Rihal.WebServer.Services.Interfaces;

namespace Rihal.WebServer.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public async Task<StudentsStatisticsOutputDto> GetStudentsStatistics()
        {

           var studentsPerClass    = await _studentRepository.GetCountStudentsPerClass();
           var studentsPerCountry  = await _studentRepository.GetCountStudentsPerCountry();
           var studentsDateOfBirth = await _studentRepository.GetStudentsDateOfBirth();

            return new StudentsStatisticsOutputDto() 
              {
                  AverageStudentsAge = CalculateStudentsAverageAge(studentsDateOfBirth),
                  StudentsPerClass = studentsPerClass.Select(student => StudentsPerClassOutputDto.Map(student)).ToList(),
                  StudentsPerCountry = studentsPerCountry.Select(student => StudentsPerCountryOutputDto.Map(student)).ToList(),
              };
        }

        private int CalculateStudentsAverageAge(List<DateTime> studentsDateOfBirth)
        {
            var today = DateTime.Today;
            var studentsAverageAge = 0;

            foreach (var studentDateOfBirth in studentsDateOfBirth)
            {
                var studentAge = today.Year - studentDateOfBirth.Year;

                // in case student was porn in a leap year
                if (studentDateOfBirth.Date > today.AddYears(-studentAge))
                    studentAge--;

                studentsAverageAge += studentAge;
            }

            return studentsAverageAge / studentsDateOfBirth.Count();
        }
    }
}
