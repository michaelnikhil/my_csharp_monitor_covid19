﻿using CsvHelper;
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
        public string output;
        public List<string> l_output = new List<string> { };
        public bool success = false;
        public string data;
        public Hashtable lastValue = new Hashtable();
        public Dictionary<string, Country> dictCountry = new Dictionary<string, Country> { }; 


        public void DownloadCovid(MyFileChoice source) {

            string url;
            if (source == MyFileChoice.CurrentDeaths) {
                url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_deaths_global.csv";
            }
            else
            {
                url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
            }

            try {
                var request = WebRequest.Create(url) as HttpWebRequest;
                var response = request.GetResponse() as HttpWebResponse;
                var status = response.StatusCode; //returns OK if a response is received
                success = true;
                output = status.ToString();

                // The using statement also closes the StreamReader
                using (StreamReader stream = new StreamReader(response.GetResponseStream())) {
                    ReadTimeSeries(stream,source);
                }

            } catch (WebException ex) {
                output = ex.Message;
                return;
            }
        }


        public void DownloadPopulation() {

            string url = "https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/UID_ISO_FIPS_LookUp_Table.csv";
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
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.MissingFieldFound = null;
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
        public void ReadTimeSeries(StreamReader str, MyFileChoice source) {
            //TODO : refactor code to download the dates only once

            using (CsvReader csv = new CsvReader(str, CultureInfo.InvariantCulture)) {
                //1. read header to collect the dates
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
                //2. add missing data to the dictCountry = the last column of the table
                //last column points to the current day

                //change where the data is sent depending on the file
                if (source == MyFileChoice.CurrentDeaths) {  
                    while (csv.Read())
                    {
                        string values = csv.GetField(headerRow.Last());
                        string str_count = csv.GetField("Country/Region");
                        if (dictCountry.ContainsKey(str_count))
                        {
                            //sum all values corresponding to the same country
                            dictCountry[str_count].CurrentDeaths += Convert.ToInt32(values);

                            l_output.Add(dictCountry[str_count].Country_Region);
                        }
                    }
                }
                else //confirmedCases
                {
                    while (csv.Read())
                    {
                        string values = csv.GetField(headerRow.Last());
                        string str_count = csv.GetField("Country/Region");
                        if (dictCountry.ContainsKey(str_count))
                        {
                            //sum all values corresponding to the same country
                            dictCountry[str_count].CurrentConfirmedCases += Convert.ToInt32(values);

                            l_output.Add(dictCountry[str_count].Country_Region);
                        }
                    }
                }
            }
        }

        public static List<string> OrderVal (Dictionary<string, Country> dict,int rank, MyOrderBy by) {
            List<string> orderedList = new List<string> { };
            switch (by) {
                case MyOrderBy.Population:
                    orderedList = (from entry in dict
                                       where (!String.IsNullOrEmpty((entry.Value.Population)))
                                       orderby
                                       (Convert.ToInt32(entry.Value.Population)) descending
                                       select entry.Key).Take(rank).ToList<string>();
                    break;
                case MyOrderBy.CurrentConfirmedCases:
                    orderedList = (from entry in dict     
                                   orderby entry.Value.CurrentConfirmedCases descending                                
                                   select entry.Key).Take(rank).ToList<string>();
                    break;
                case MyOrderBy.CurrentDeaths:
                    orderedList = (from entry in dict
                                   orderby entry.Value.CurrentDeaths descending
                                   select entry.Key).Take(rank).ToList<string>();
                    break;
                default:
                    break;
            }
            return orderedList;
        }
    }

    public enum MyFileChoice
    {
        CurrentConfirmedCases,
        CurrentDeaths
    }
}
