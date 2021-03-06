﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataProcessing;

namespace WebApplication1.Models
{
    public class SummaryData
    {

        private static LoadData LoadAllData()
        {
            //create an instance of the loaddata class and download all the data
            LoadData loader = new LoadData();
            loader.DownloadPopulation();
            loader.DownloadCovid(MyFileChoice.CurrentDeaths);
            //loader.DownloadCovid(MyFileChoice.CurrentConfirmedCases);
            loader.DownloadPopulation();
            return loader;
        }

        public static List<object> KeyIndicatorCurrentDeaths()
        {
            //create an instance of the loaddata class and download all the data
            LoadData loader = LoadAllData();

            //order the countries
            int rank = 10;
            List<string> orderCountries = LoadData.OrderVal(loader.dictCountry, rank, MyOrderBy.CurrentDeaths);

            List<object> objs = new List<object>();
            objs.Add(new object[] { "Country", "Deaths" });

            //populate the datatable

            foreach (string country in orderCountries)
            {
                objs.Add(new object[] { country, loader.dictCountry[country].CurrentDeaths });
            }

            return objs;
        }

        public static List<object> TimeSeries()
        {
            List<object> objs = new List<object>();
            
            //create an instance of the loaddata class and download all the data
            LoadData loader = LoadAllData();


            //order the countries
            int rank = 4;
            List<string> orderCountries = LoadData.OrderVal(loader.dictCountry, rank, MyOrderBy.CurrentDeaths);

            //build the sample datatable

            object[] header = new object[rank + 1];

            //create columns
            header[0] = "date";
            for (int i = 0; i < orderCountries.Count; i++)
            {
                header[i+1] = orderCountries[i];
            }
            objs.Add(header);

            //populate the datatable
            for (int i = 0; i < loader.dates.Count; i++)
            {
                //TODO : dispose objects
                object[] array = new object[rank + 1];
                array[0] = loader.dates[i];
                for (int j = 0; j < rank; j++)
                {
                    array[j + 1] = loader.dictCountry[orderCountries[j]].timeSeries[i];
                }
                objs.Add(array);
            }

            return objs;
        }

    }
}
