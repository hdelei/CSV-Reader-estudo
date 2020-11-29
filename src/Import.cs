using CsvHelper;
using System;
using System.Data;
using System.Globalization;
using System.IO;

namespace TesteVitor1
{
    class Import
    {
        private string csvLocation;
        private DataTable dt = new DataTable();

        public Import(string csvLocation, DataTable dt)
        {
            this.csvLocation = csvLocation;
            this.dt = dt;
        }

        public DataTable CSVToDataTable()
        {
            using (var reader = new StreamReader(csvLocation))
            
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                using (var dr = new CsvDataReader(csv))
                {                    
                    dt.Load(dr);
                }
            }

            var newDt = WriteHeader();

            return newDt;
        }

        private DataTable WriteHeader()
        {
            DataTable newDt = new DataTable();
            newDt.Columns.Add("Name", typeof(String));
            newDt.Columns.Add("City", typeof(String));
            newDt.Columns.Add("Age", typeof(int));

            foreach (DataRow dr in dt.Rows)
            {
                newDt.Rows.Add(dr.ItemArray);
            }

            return newDt;
        }
    }
}
