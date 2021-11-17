# Cohesion Automation Challenge Project ###

### Steps to execute tests

#### CLI
1. In the project base folder

       dotnet build
       dotnet test

2. That's it ;)

#### UI
1. Right click on "ChicagoWeatherTest" class
2. Click on "Run Tests"

### Technologies

* C# (.NET Core)
* RestSharp
* NUnit

### Approach

* Use RestSharp client to make the requests to API.
* Use NUnit for assertions
* Create Models in order to deserialize Json Objects from API responses.
* Create basic Automation Framework structure

       Helpers
        |_ ApiHelper.cs
       Models
        |_ Measurement.cs
       Tests
        |_ ChicagoWeatherTest.cs
