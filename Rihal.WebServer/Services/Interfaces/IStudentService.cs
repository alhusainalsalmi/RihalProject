using Rihal.WebServer.Dtos.OutputDtos;

namespace Rihal.WebServer.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentsStatisticsOutputDto> GetStudentsStatistics();
    }
}
