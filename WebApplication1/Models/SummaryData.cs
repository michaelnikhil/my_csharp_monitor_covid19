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

        public static List<object> MultiLineData()
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
            DataTable table = new DataTable();

            //create columns
            table.Columns.Add("date", typeof(DateTime));
            foreach ( string country in orderCountries)
            {
                table.Columns.Add(country, typeof(int));
            }

            //populate the datatable
           /* for (int i = 0; i < loader.dates.Count; i++)
            {
                table.Rows.Add(25, "Indocin", "David", DateTime.Now);

                foreach (var item in collection)
                {

                }
                objs.Add(new object[] { loader.dates[i], loader.dictCountry["France"].timeSeries[i], loader.dictCountry["Italy"].timeSeries[i] });

            }*/

            objs.Add(new[] { "dates","France", "Italy" });



            for (int i = 0; i < loader.dates.Count; i++)
            {
                objs.Add(new object[] {loader.dates[i], loader.dictCountry["France"].timeSeries[i], loader.dictCountry["Italy"].timeSeries[i] });

            }

            //objs.Add()
            /*
            objs.Add(new[] { "x", "sin(x)", "cos(x)", "sin(x)^2" });
            for (int i = 0; i < 70; i++)
            {
                double x = 0.1 * i;
                objs.Add(new[] { x, Math.Sin(x), Math.Cos(x), Math.Sin(x) * Math.Sin(x) });
            }*/
            return objs;
        }

    }
}
