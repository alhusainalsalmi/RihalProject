using Rihal.Domain.Entities;


namespace Rihal.DataAccess.SeedingData
{
    public class ClassesTableData
    {
        public static readonly List<Class> ClassesData = new List<Class>()
        {
            new Class(){ClassId=1, Name="COMP103"},
            new Class(){ClassId=2, Name="COMP105"},
            new Class(){ClassId=3,Name="COMP110"}
        };

    }
}
