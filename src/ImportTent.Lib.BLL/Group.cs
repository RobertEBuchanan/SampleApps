using CsvHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ImportTent.Lib.BLL
{

    public class Group : IExportImport, IGroup
    {
        #region Properties

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Comment { get; set; }

        public bool Active { get; set; }

        public int Years { get; set; }

        public int ActiveYears { get; set; }

        public int FilingCount { get; set; }

        #endregion Properties/

        #region Methods

        public Group() { }

        public List<IGroup> Import(string csvFile)
        {
            using (var stream = GenerateStreamFromString(csvFile))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                //csv.Configuration.RegisterClassMap<TestMap>();
                var records = csv.GetRecords<Group>();
                //// View records in LINQPad
                var result =  new List<IGroup>(records.ToList<Group>());
                return result;
            }
        }

        public string Export(List<IGroup> records)
        {
            using (var stream = new MemoryStream())
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
                writer.Flush();
                stream.Position = 0;
                return reader.ReadToEnd();
            }
        }

        private static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        #endregion Methods/
    }

    /*
     https://github.com/JoshClose/CsvHelper/issues/255

     */
}
