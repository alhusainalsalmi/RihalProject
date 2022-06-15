using Microsoft.EntityFrameworkCore;
using Rihal.DataAccess.DbContext;
using Rihal.Domain.Exceptions;
using Rihal.Domain.Repositories;
using Rihal.Domain.ValueObjects;

namespace Rihal.DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly RihalDbContext _rihalDbContext;
        public StudentRepository(RihalDbContext rihalDbContext)
        {
            _rihalDbContext = rihalDbContext ?? throw new ArgumentNullException(nameof(rihalDbContext));
        }

        public async Task<List<DateTime>> GetStudentsDateOfBirth()
        {
            var output = await _rihalDbContext.Students
                   .Select(student => student.DateOfBirth).ToListAsync();

            if (output == null)
                throw new RihalAppNullException($"error in fetching studentsDateOfBirth {typeof(StudentRepository)} ");

            return output;
        }

        public async Task<List<StudentsPerClass>> GetCountStudentsPerClass()
        {         
           var output = await _rihalDbContext.Students
                .Include(st => st.Class)
                .GroupBy(st => st.ClassId)
                .Select(st => new StudentsPerClass { ClassName = st.Select(c=>c.Class.Name).First(), NumberOfStudents = st.Count() })
                .ToListAsync();

            if (output == null)
                throw new RihalAppNullException($"error in fetching CountStudentsPerClass {typeof(StudentRepository)} ");

            return output;
        }

        public async Task<List<StudentsPerCountry>> GetCountStudentsPerCountry()
        {
            var output = await _rihalDbContext.Students
                .Include(st => st.Country)
                .GroupBy(st => st.CountryId)
                .Select(st => new StudentsPerCountry { CountryName = st.Select(c => c.Country.Name).First(), NumberOfStudents = st.Count() })
                .ToListAsync();

            if (output == null)
                throw new RihalAppNullException($"error in fetching CountStudentsPerCountry {typeof(StudentRepository)}");

            return output;
        }
    }
}
