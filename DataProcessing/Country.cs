using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;


namespace DataProcessing {

    public class Country {

        public string Country_Region { get; set; }
        public string Population { get; set; }
        
        public int nPopulation() {
            return Int32.Parse(Population);
        }

// public List<int> timeSeries;

        public void Nvalues() { }

    }
}
