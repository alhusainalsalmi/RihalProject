using Rihal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rihal.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<StudentsPerClass>> GetCountStudentsPerClass();
        Task<List<StudentsPerCountry>> GetCountStudentsPerCountry();
        Task<List<DateTime>> GetStudentsDateOfBirth();

    }
}
