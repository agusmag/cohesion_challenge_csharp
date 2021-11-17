using NUnit.Framework;

namespace cohesion_challenge_cs.Tests
{
    public class ChicagoWeatherTest
    {
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
            Assert.Pass();
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
            Assert.Pass();
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
