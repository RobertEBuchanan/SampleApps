using System.Collections.Generic;

namespace ImportTent.Lib.BLL
{
    public interface IExportImport
    {
        string Abbreviation { get; set; }
        bool Active { get; set; }
        int ActiveYears { get; set; }
        string Comment { get; set; }
        int FilingCount { get; set; }
        string Name { get; set; }
        int Years { get; set; }

        List<IGroup> Import(string csvFile);
        string Export(List<IGroup> groups);
    }
    public interface IGroup
    {
        string Abbreviation { get; set; }
        bool Active { get; set; }
        int ActiveYears { get; set; }
        string Comment { get; set; }
        int FilingCount { get; set; }
        string Name { get; set; }
        int Years { get; set; }

       
    }
}