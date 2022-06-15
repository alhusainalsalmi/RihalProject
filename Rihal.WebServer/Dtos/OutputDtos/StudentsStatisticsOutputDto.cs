namespace Rihal.WebServer.Dtos.OutputDtos
{
    public class StudentsStatisticsOutputDto
    {
        public List<StudentsPerClassOutputDto> StudentsPerClass { get; set; } = new List<StudentsPerClassOutputDto>();
        public List<StudentsPerCountryOutputDto> StudentsPerCountry { get; set; } = new List<StudentsPerCountryOutputDto>();
        public int AverageStudentsAge { get; set; }
    }
}
