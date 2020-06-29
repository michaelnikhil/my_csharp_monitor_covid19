using CsvHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Linq;

namespace DataProcessing {
    public class LoadData {

        public List<DateTime> dates = new List<DateTime> { };
        public string url;
        public string output;
        public List<string> l_output = new List<string> { };
        public bool success = false;
        public string data;
        public Hashtable lastValue = new Hashtable();
        public Dictionary<string, Country> dictCountry = new Dictionary<string, Country> { }; 

        public void DownloadCovid() {
            try {
                var request = WebRequest.Create(url) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                var status = response.StatusCode; //returns OK if a response is received
                success = true;
                output = status.ToString();

                // The using statement also closes the StreamReader
                using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
                    ReadTimeSeries(stream);
                }

            } catch (WebException ex) {
                output = ex.Message;
                return;
            }
        }

        public void DownloadPopulation() {

            try {
                var request = WebRequest.Create(url) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                var status = response.StatusCode; //returns OK if a response is received
                success = true;
                output = status.ToString();

                // The using statement also closes the StreamReader
                using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
                    ReadPopulation(stream);
                }

            } catch (WebException ex) {
                output = ex.Message;
                return;
            }
        }
        
        public void ReadPopulation(StreamReader str) {
            //read data and map the columns against the Country class
            using (CsvReader csv = new CsvReader(str, CultureInfo.InvariantCulture)) {
                var records = csv.GetRecords<Country>();
                
                foreach  (var record in records) {
                    if (!dictCountry.ContainsKey(record.Country_Region)){
                        dictCountry.Add(record.Country_Region, record);
                    }

                    if (!lastValue.ContainsKey(record.Country_Region)) {
                        lastValue.Add(record.Country_Region,record.Population.ToString());
                    }
                }
            }
        }
        public void ReadTimeSeries(StreamReader str) {

            using (CsvReader csv = new CsvReader(str, CultureInfo.InvariantCulture)) {
                //read header to collect the dates
                csv.Read();
                csv.ReadHeader();
                CultureInfo culture = new CultureInfo("en-US");
                culture.Calendar.TwoDigitYearMax = 2099;
                string[] headerRow = csv.Context.HeaderRecord;
                foreach (string item in headerRow) {
                    if (DateTime.TryParse(item, culture,
                        DateTimeStyles.None,
                        out DateTime date)) {
                        dates.Add(date);
                    }                           
                }
            }
        }

        public static List<string> OrderVal (Dictionary<string, Country> dict) {
            var orderedList = (from entry in dict
                               where (!String.IsNullOrEmpty((entry.Value.Population)))
                               orderby 
                               (Convert.ToInt32( entry.Value.Population)) descending
                               select entry.Key).Take(10).ToList<string>();
            return orderedList;
        }


    }
}
