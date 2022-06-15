using Rihal.Domain.ValueObjects;

namespace Rihal.WebServer.Dtos.OutputDtos
{
    public class StudentsPerClassOutputDto
    {
        public string ClassName { get; set; }
        public int NumberOfStudents { get; set; }

        public static StudentsPerClassOutputDto Map(StudentsPerClass studentsPerClass)
        {
            return new StudentsPerClassOutputDto
            {
                ClassName = studentsPerClass.ClassName,
                NumberOfStudents = studentsPerClass.NumberOfStudents
            };
        }
    }
}
