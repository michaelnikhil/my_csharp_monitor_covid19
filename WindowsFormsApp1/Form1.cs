using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataProcessing;

namespace WindowsFormsApp1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            LoadData loader = new LoadData();

            loader.url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/UID_ISO_FIPS_LookUp_Table.csv";

            loader.DownloadPopulation();
            if (!loader.success) {
                MessageBox.Show(loader.output);
            }


            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add("Country", "Country");
            dataGridView1.Columns.Add("Population", "Population");

           // MessageBox.Show(loader.output);

            foreach (string item in loader.lastValue.Keys) {
                dataGridView1.Rows.Add(new object[] { item, loader.lastValue[item] });
            }

            loader.url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_global.csv";
           
           loader.DownloadCovid();
            if (!loader.success) {
                MessageBox.Show(loader.output);
            }
         /*
            foreach (string item in loader.l_output) {
                listBox1.Items.Add(item);
            }*/
            foreach (var item in loader.dates) {
                listBox1.Items.Add(item);
            }


        }
    }
}
