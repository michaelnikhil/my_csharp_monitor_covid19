using CsvHelper;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Net;


namespace DataProcessing {
    public class LoadData {
        public string url;
        public string output;
        public bool success = false;
        public string data;
        public Hashtable lastValue = new Hashtable();

        public void DownloadCovid() {

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
                    Readtext(stream);
                }

            } catch (WebException ex) {
                output = ex.Message;
                return;
            }
        }

        public void Readtext(StreamReader str) {
            
            using (CsvReader csv = new CsvReader(str, CultureInfo.InvariantCulture)) {
                var records = csv.GetRecords<Country>();
                foreach  (var record in records) {
                    if (!lastValue.ContainsKey(record.Country_Region)) {
                        lastValue.Add(record.Country_Region,record.Population);
                    }
                }
            }
        }

    }
}
