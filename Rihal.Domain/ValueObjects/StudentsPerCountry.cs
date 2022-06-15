using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rihal.Domain.ValueObjects
{
    public class StudentsPerCountry
    {
        public string CountryName { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
