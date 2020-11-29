using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TesteVitor1
{
    public partial class MainForm : Form
    {
        DataTable sourceDataTable = new DataTable();
        DataTable formattedDataTable = new DataTable();

        public MainForm()
        {
            InitializeComponent();
        }

        const byte FILL_DGV = 0;
        const byte CALC_AVG = 1;
        const byte MAKE_JSON = 2;
        const byte POST_DATA = 3;
        const byte RELOAD = 4;

        byte buttonAction = FILL_DGV;

        private void MyButton_Click(object sender, EventArgs e)
        {
            switch (buttonAction)
            {
                case FILL_DGV:
                    FillDataGridView();
                    //ShowJson(formattedDataTable);
                    myButton.Text = "Calculate Average";
                    labelSub.Text = "Fill Average DataGridView with calculated data";
                    break;

                case CALC_AVG:
                    CalculateAverage();

                    myButton.Text = "Make JSON Object";
                    labelSub.Text = "Generate JSON structure before posting";
                    break;

                case MAKE_JSON:
                    ShowJson(formattedDataTable);
                    myButton.Text = "Post JSON";
                    labelSub.Text = "Post JSON to hipothetical Api";
                    break;

                case POST_DATA:
                    PostJson(formattedDataTable);
                    myButton.Text = "Reload Form";
                    labelSub.Text = "Reset form and make it again and again...";
                    break;

                default:
                    ReloadForm();
                    break;
            }

            buttonAction++;

            if (buttonAction > RELOAD)
            {
                buttonAction = FILL_DGV;
            }
        }

        //private string csvPath = @"D:\testvic\input.csv";
        private string csvPath = "";

        private void FillDataGridView()
        {
            var import = new Import(csvPath, sourceDataTable);
            sourceDataTable = import.CSVToDataTable();
            dgvData.DataSource = sourceDataTable;

            //TODO: format DataDgridView
        }

        private void CalculateAverage()
        {
            formattedDataTable = sourceDataTable.Copy();

            foreach (DataRow dtRow in formattedDataTable.Rows)
            {
                foreach (DataColumn dtColumn in formattedDataTable.Columns)
                {
                    var field = dtRow[dtColumn];
                    //System.Diagnostics.Debug.WriteLine(dtRow[dtColumn]);
                    if (field.GetType() != typeof(int))
                    {
                        dtRow[dtColumn] = RemoveDiacritics(field.ToString());
                    }
                }
            }

            var pList = new List<People>();

            //Make Objects list from Datatable
            //adapted from stackOverflow
            pList = (from rw in formattedDataTable.AsEnumerable()
                     select new People()
                     {
                         Name = Convert.ToString(rw["Name"]),
                         Age = Convert.ToInt32(rw["Age"]),
                         City = Convert.ToString(rw["City"])
                     }).ToList();

            var calculate = new Calculate(pList);
            var ageAverageList = calculate.GetAverageList;
            var averageCitiesList = calculate.GetCities;

            var tbFactory = new TableFactory(averageCitiesList.Count);
            tbFactory.SetColumn(averageCitiesList, "City");
            tbFactory.SetColumn(ageAverageList, "Age");
            var averageTable = tbFactory.GetTable;
            dgvAverage.DataSource = averageTable;
            formattedDataTable = averageTable;
        }

        private void ReloadForm()
        {
            Application.Restart();
        }

        private void ShowJson(DataTable myTable)
        {
            try
            {
                var jsonString = "{\r\n\"Average\":"; //can be improved                
                jsonString += JsonConvert.SerializeObject(myTable, Formatting.Indented);
                jsonString += "\r\n}";
                txt.Text = jsonString;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Extracted from StackOverflow
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
        }

        //Ignore little type mistakes in city names
        static bool IsTheSameLocation(string placeA, string placeB)
        {
            return RemoveDiacritics(placeA) == RemoveDiacritics(placeB);
        }

        public void PostJson(DataTable myTable)
        {
            var jsonString = "{\"Average\":";
            jsonString += JsonConvert.SerializeObject(myTable);
            jsonString += "}";

            var data = Encoding.UTF8.GetBytes(jsonString);
            var request = WebRequest.CreateHttp("https://httpbin.org/anything");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.UserAgent = "DemoRequest";

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Close();
            }

            using (var response = request.GetResponse())
            {
                var streamDados = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                System.Diagnostics.Debug.WriteLine(objResponse.ToString());
                streamDados.Close();
                response.Close();
            }
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvAverage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgvAverage.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "csv files (*.csv)|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                csvPath = openFileDialog1.FileName;
                fileBox.Text = csvPath;
                myButton.Enabled = true;
            }
        }
    }
}
