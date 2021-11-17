using System;
namespace cohesion_challenge_cs.Models
{
    public class Measurement
    {
        public string station_name { get; set; }

        public string measurement_timestamp { get; set; }

        public string air_temperature { get; set; }

        public string wet_bulb_temperature { get; set; }

        public string humidity { get; set; }

        public string rain_intensity { get; set; }

        public string interval_rain { get; set; }

        public string total_rain { get; set; }

        public string precipitation_type { get; set; }

        public string wind_direction { get; set; }

        public string wind_speed { get; set; }

        public string maximun_wind_speed { get; set; }

        public string barometric_pressure { get; set; }

        public string solar_radiation { get; set; }

        public string heading { get; set; }

        public string battery_life { get; set; }

        public string measuremen_timestamp_label { get; set; }

        public string measurement_id { get; set; }

        public Measurement() { }
    }
}
