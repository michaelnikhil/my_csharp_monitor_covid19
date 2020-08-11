using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DataProcessing;

namespace WebApplication1.Models
{
    public class SummaryData
    {
        public static readonly IEnumerable<DataProcessing.Country> CountryData = new[] {
            new Country {
                Country_Region = "France",
                Population = "10"
            },
            new Country {
                Country_Region = "Sweden",
                Population = "15"
            },
            new Country {
                Country_Region = "Belgium",
                Population = "8"
            }
        };

        public static List<object> KeyIndicators()
        {
            List<object> objs = new List<object>();
            objs.Add(new object[] { "Year", "Asia" });
            objs.Add(new object[] { "2012", 1000 });
            objs.Add(new object[] { "2013", 1170 });
            objs.Add(new object[] { "2014", 1250 });
            objs.Add(new object[] { "2015", 900 });
            objs.Add(new object[] { "2016", 1530 });

            return objs;
        }

        public static List<object> TimeSeries()
        {
            List<object> objs = new List<object>();
            
            //create an instance of the loaddata class and download all the data
            LoadData loader = new LoadData();
            loader.DownloadPopulation();
            loader.DownloadCovid(MyFileChoice.CurrentDeaths);

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
