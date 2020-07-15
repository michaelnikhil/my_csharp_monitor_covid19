using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DataProcessing;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {


            //create an instance of the loaddata class and populate it 
            LoadData loader = LoadAllData();

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("Population", "Population");
            dataGridView1.Columns.Add("Deaths", "Deaths");

            foreach (string item in loader.dictCountry.Keys) {
                Country cc = loader.dictCountry[item];
                dataGridView1.Rows.Add(new object[] { item, cc.Population, cc.CurrentDeaths });
               // System.Diagnostics.Debug.Write("\"" + item + "\",");
            }


            List<string> orderCountries = LoadData.OrderVal(loader.dictCountry,10,MyOrderBy.Population);
               foreach (var item in orderCountries) {
                   listBox2.Items.Add(item);
               }
            drawChart(loader.dictCountry,orderCountries);

        }

        private LoadData LoadAllData(){

         //create an instance of the loaddata class
            LoadData loader = new LoadData();

            loader.url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/UID_ISO_FIPS_LookUp_Table.csv";
            loader.DownloadPopulation();

            if (!loader.success) {
                MessageBox.Show(loader.output);
            }

            loader.url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_global.csv";
           
           loader.DownloadCovid();
            if (!loader.success) {
                MessageBox.Show(loader.output);
            }
        
            return loader;
        }

        private void drawChart(Dictionary<string, Country> dict, List<string> listCountries) {

            Series ser1 = new Series("My Series");
            chart1.Series.Add(ser1);

            foreach (string item in listCountries) {
                Country cc = dict[item];
                chart1.Series["My Series"].Points.AddXY(item, cc.Population);

            }
        }
    }
}
