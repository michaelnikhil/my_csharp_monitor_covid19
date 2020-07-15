using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using DataProcessing;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UnitTestProject {
    [TestClass]
    public class UnitTest1 {
   
        //this test checks that the list of countries downloaded from github is as expected
        [TestMethod]
        public void TestReadPopulationFile() {
            //arrange
            LoadData loader = new LoadData();

            //act
            loader.DownloadPopulation();
            List<string> listActual = new List<string> { };

            foreach (string item in loader.dictCountry.Keys) {
                listActual.Add(item);
                Debug.Write(item);
            }

            // Assert
            List<string> listExpected = new List<string> { "Afghanistan", "Albania",  "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Central African Republic", "Chad", "Chile", "Colombia", "Congo (Brazzaville)", "Congo (Kinshasa)", "Comoros", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czechia", "Denmark", "Diamond Princess", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Holy See", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Korea, South", "Kosovo", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Mauritania", "Mauritius", "Mexico", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "MS Zaandam", "Namibia", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Macedonia", "Norway", "Oman", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Somalia", "South Africa", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Taiwan*", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Trinidad and Tobago", "Tunisia", "Turkey", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "Uruguay", "Uzbekistan", "Venezuela", "Vietnam", "West Bank and Gaza", "Western Sahara", "Yemen", "Zambia", "Zimbabwe", "Australia", "Canada", "China", "US"};

            //assert
            CollectionAssert.AreEqual(listExpected, listActual, "the list of countries has changed");

        }

        //parametrised unit test
        [DataRow(MyFileChoice.CurrentConfirmedCases)]
        [DataRow(MyFileChoice.CurrentDeaths)]

        [DataTestMethod]
        public void TestDownloadCovid_GetCurrentDate(MyFileChoice source)
        {
            //arrange
            LoadData loader = new LoadData();

            //act
            loader.DownloadCovid(source);
            DateTime lastLoggedDate = loader.dates.Last();
            DateTime todayDate = DateTime.Now;
            Debug.WriteLine(lastLoggedDate);
            Debug.WriteLine(todayDate);

            TimeSpan date_span = (todayDate - lastLoggedDate).Duration();

            // Assert
            //return true if the last logged day is the current day +/- 2 days
            bool result = date_span.Days < 2 ? true : false;

            Assert.IsTrue(result, "the date differs by more than 2 days");  
        }

    }



}
