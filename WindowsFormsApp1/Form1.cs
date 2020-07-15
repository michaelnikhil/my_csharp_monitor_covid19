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
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("Population", "Population");
            dataGridView1.Columns.Add("Confirmed cases", "Confirmed cases");
            dataGridView1.Columns.Add("Deaths", "Deaths");

            foreach (string item in loader.dictCountry.Keys) {
                Country cc = loader.dictCountry[item];
                dataGridView1.Rows.Add(new object[] { item, cc.Population,cc.CurrentConfirmedCases, cc.CurrentDeaths });
               // System.Diagnostics.Debug.Write("\"" + item + "\",");
            }

            int comboBoxChoice = comboBox1.SelectedIndex;

            //TODO : fix the method
            List<string> orderCountries = LoadData.OrderVal(loader.dictCountry,4,(MyOrderBy)comboBoxChoice  );
               foreach (var item in orderCountries) {
                   listBox2.Items.Add(item);
               }
            drawChart(loader.dictCountry,orderCountries, comboBoxChoice);

        }

        private LoadData LoadAllData(){

         //create an instance of the loaddata class
            LoadData loader = new LoadData();
           
            loader.DownloadPopulation();

            if (!loader.success) {
                MessageBox.Show(loader.output);
            }


           loader.DownloadCovid();
            if (!loader.success) {
                MessageBox.Show(loader.output);
            }
        
            return loader;
        }

        private void drawChart(Dictionary<string, Country> dict, List<string> listCountries, int comboBoxChoice) {

            chart1.Series.Clear();
            Series ser1 = new Series();
            chart1.Series.Add(ser1);
            


            //TODO : improve the choice (remove switch)
            switch (comboBoxChoice)
            {
                case 0: //population

                    ser1.Name = "Population";
                    foreach (string item in listCountries)
                    {
                        Country cc = dict[item];

                        chart1.Series["Population"].Points.AddXY(item, cc.Population);
                    }
                    break;
                case 1: //confirmed cases
                    ser1.Name = "Confirmed cases";
                    foreach (string item in listCountries)
                    {
                        Country cc = dict[item];

                        chart1.Series["Confirmed cases"].Points.AddXY(item, cc.CurrentConfirmedCases);
                    }
                    break;
                case 2: //current deaths
                    ser1.Name = "Current deaths";
                    foreach (string item in listCountries)
                    {
                        Country cc = dict[item];

                        chart1.Series["Current deaths"].Points.AddXY(item, cc.CurrentDeaths);
                    }
                    break;

                default:
                    break;
            }

            chart1.ChartAreas[0].RecalculateAxesScale();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
