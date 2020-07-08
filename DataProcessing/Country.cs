using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace DataProcessing {

    public class Country {

        public string Country_Region { get; set; }
        public string Population { get; set; }
        public int CurrentConfirmedCases { get; set; }
        public int CurrentDeaths { get; set; }
        public List<int> timeSeries;

        public void Nvalues() { }

    }

    public enum MyOrderBy {
        Population,
        CurrentConfirmedCases,
        CurrentDeaths
    }
}
