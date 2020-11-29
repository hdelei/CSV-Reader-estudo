using System;
using System.Collections.Generic;
using System.Data;

namespace TesteVitor1
{
    class TableFactory
    {
        private DataTable getTable;
        private int columnIndex = 0;
        //test

        public TableFactory(int tableLength)
        {
            getTable = new DataTable();

            //Initialize table with empty rows
            for (int i = 0; i < tableLength; i++) {
                getTable.Rows.Add();
            }            
        }

        public DataTable GetTable { get => getTable;}

        public bool SetColumn<T>(List<T> column, string header)
        {           
            try
            {
                CopyColumnToTable(column, header);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }        

        /// <summary>
        /// This method add rows based on a List
        /// Every time it's accessed, index is iterated to create a new column
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <param name="header"></param>
        private void CopyColumnToTable<T>(List<T> column, string header)
        {
            //var type = column.GetType();
            getTable.Columns.Add(header, typeof(string));

            var i = 0;
            foreach (T  t in column)
            {             
                GetTable.Rows[i++][columnIndex] = t;
            }
            columnIndex++;
        }
    }
}
