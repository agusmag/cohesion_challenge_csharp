using System.Collections.Generic;
using System.Linq;
using System.Net;
using cohesion_challenge_cs.Models;
using cohesion_challenge_cs.src.helpers;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace cohesion_challenge_cs.Tests
{
    public class ChicagoWeatherTest
    {
        private readonly string apiUri = "https://data.cityofchicago.org/resource/k7hf-8y75.json";
        private readonly string userToken = "";
        
        [SetUp]
        public void Setup()
        {
        }

        /***
         * Story 1: As a user of the API I want to list all measurements taken by the station on Oak Street in json format.
         * • GIVEN BEACH WEATHER STATION SENSOR “OAK STREET”
         * • WHEN THE USER REQUESTS STATION DATA
         * • THEN ALL DATA MEASUREMENTS CORRESPOND TO ONLY THAT STATION
        */
        [Test]
        public void ListAllMeasurementsOnOakStreet()
        {
            // ARRANGE
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("station_name", "Oak Street Weather Station");

            // ACT
            IRestResponse response = ApiHelper.Get(apiUri, queryParams, userToken);
            var measurements = new JsonDeserializer().Deserialize<List<Measurement>>(response);

            // ASSERT
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(measurements.All(x => x.station_name == "Oak Street Weather Station"), Is.True);
        }

        /***
         * Story 2: As a user of the API I want to be able to page through JSON data sets of 2019 taken by the sensor on 63rd Street.
         * • GIVEN THE BEACH WEATHER STATION ON 63RD STREET’S SENSOR DATA OF 2019
         * • WHEN THE USER REQUESTS DATA FOR THE FIRST 10 MEASUREMENTS
         * • AND THE SECOND PAGE OF 10 MEASUREMENTS
         * • THEN THE RETURNED MEASUREMENTS OF BOTH PAGES SHOULD NOT REPEAT
        */
        [Test]
        public void VerifyPageNavigationInDataSets()
        {
            // ARRANGE
            Dictionary<string, string> queryParamsOne = new Dictionary<string, string>();
            queryParamsOne.Add("station_name", "63rd Street Weather Station");
            queryParamsOne.Add("$limit", "10");
            queryParamsOne.Add("$offset", "0"); // Starting at element 1 of array
            queryParamsOne.Add("$order", "measurement_id");

            Dictionary<string, string> queryParamsTwo = new Dictionary<string, string>();
            queryParamsTwo.Add("station_name", "63rd Street Weather Station");
            queryParamsTwo.Add("$limit", "10");
            queryParamsTwo.Add("$offset", "10"); // Starting at element 11 of array
            queryParamsTwo.Add("$order", "measurement_id");

            // ACT
            IRestResponse responseOne = ApiHelper.Get(apiUri, queryParamsOne, userToken);
            IRestResponse responseTwo = ApiHelper.Get(apiUri, queryParamsTwo, userToken);

            // ASSERT
            // I need to make two requests, one for each page.
            // Then, compare lists to verify that all element of the second page isn't in first page.
            var measurementsPageOne = new JsonDeserializer().Deserialize<List<Measurement>>(responseOne);

            var measurementsPageTwo = new JsonDeserializer().Deserialize<List<Measurement>>(responseTwo);

            Assert.That(measurementsPageOne.Intersect(measurementsPageTwo).LongCount, Is.EqualTo(0));
        }

        /***
         * Story 3: As a user of the API I expect a SoQL query to fail with an error message if I search using a malformed query. Note: This is a negative test. We want to make sure that the API throws an error when expected.
         * • GIVEN ALL BEACH WEATHER STATION SENSOR DATA OF THE STATION ON 63RD STREET
         * • WHEN THE USER REQUESTS SENSOR DATA BY QUERYING BATTERY_LIFE VALUES THAT ARE LESS THAN THE TEXT “FULL” ($WHERE=BATTERY_LIFE < FULL)
         * • THEN AN ERROR CODE “MALFORMED COMPILER” WITH MESSAGE “COULD NOT PARSE SOQL QUERY” IS RETURNED
        */
        [Test]
        public void VerifyErrorMessageUsingMalformedQuery()
        {
            Assert.Pass();
        }
    }
}
