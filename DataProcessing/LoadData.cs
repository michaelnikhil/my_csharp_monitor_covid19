using System;
using System.Collections;
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

                var stream = new StreamReader(response.GetResponseStream());
                Readtext(stream);
                stream.Close();
            } catch (WebException ex) {
                output = ex.Message;
                return;
            }
        }

        public void Readtext(StreamReader str) {

            while (!str.EndOfStream) {
                string line = str.ReadLine();
                if (!String.IsNullOrWhiteSpace(line)) {
                    string[] val = line.Split(',');
                    //col7: country, col11: population
                    if (!lastValue.ContainsKey(val[7])) {
                        lastValue.Add(val[7], val[11]);
                    }
                }
            }

        }

    }
}
