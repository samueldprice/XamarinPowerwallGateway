using Newtonsoft.Json;

namespace App1.Models
{
    public class Aggregates
    {
        [JsonProperty("site")]
        public Site Site { get; set; }

        [JsonProperty("battery")]
        public Battery Battery { get; set; }

        [JsonProperty("load")]
        public Load Load { get; set; }

        [JsonProperty("solar")]
        public Solar Solar { get; set; }
    }

    public class Site
    {
        //[JsonProperty("last_communication_time")]
        //public string LastCommunicationTime { get; set; }

        [JsonProperty("instant_power")]
        public string InstantPower { get; set; }

        //[JsonProperty("instant_reactive_power")]
        //public string InstantReactivePower { get; set; }

        //[JsonProperty("instant_apparent_power")]
        //public string InstantApparentPower { get; set; }

        //[JsonProperty("frequency")]
        //public string Frequency { get; set; }

        //[JsonProperty("energy_exported")]
        //public string EnergyExported { get; set; }

        //[JsonProperty("energy_imported")]
        //public string EnergyImported { get; set; }

        //[JsonProperty("instant_average_voltage")]
        //public string InstantAverageVoltage { get; set; }

        //[JsonProperty("instant_total_current")]
        //public string InstantTotalCurrent { get; set; }

        //[JsonProperty("i_a_current")]
        //public string IACurrent { get; set; }

        //[JsonProperty("i_b_current")]
        //public string IBCurrent { get; set; }

        //[JsonProperty("i_c_current")]
        //public string ICCurrent { get; set; }

        //[JsonProperty("timeout")]
        //public string Timeout { get; set; }
    }

    public class Battery
    {
        //[JsonProperty("last_communication_time")]
        //public string LastCommunicationTime { get; set; }

        [JsonProperty("instant_power")]
        public string InstantPower { get; set; }

        //[JsonProperty("instant_reactive_power")]
        //public string InstantReactivePower { get; set; }

        //[JsonProperty("instant_apparent_power")]
        //public string InstantApparentPower { get; set; }

        //[JsonProperty("frequency")]
        //public string Frequency { get; set; }

        //[JsonProperty("energy_exported")]
        //public string EnergyExported { get; set; }

        //[JsonProperty("energy_imported")]
        //public string EnergyImported { get; set; }

        //[JsonProperty("instant_average_voltage")]
        //public string InstantAverageVoltage { get; set; }

        //[JsonProperty("instant_total_current")]
        //public string InstantTotalCurrent { get; set; }

        //[JsonProperty("i_a_current")]
        //public string IACurrent { get; set; }

        //[JsonProperty("i_b_current")]
        //public string IBCurrent { get; set; }

        //[JsonProperty("i_c_current")]
        //public string ICCurrent { get; set; }

        //[JsonProperty("timeout")]
        //public string Timeout { get; set; }
    }

    public class Load
    {
        //[JsonProperty("last_communication_time")]
        //public string LastCommunicationTime { get; set; }

        [JsonProperty("instant_power")]
        public string InstantPower { get; set; }

        //[JsonProperty("instant_reactive_power")]
        //public string InstantReactivePower { get; set; }

        //[JsonProperty("instant_apparent_power")]
        //public string InstantApparentPower { get; set; }

        //[JsonProperty("frequency")]
        //public string Frequency { get; set; }

        //[JsonProperty("energy_exported")]
        //public string EnergyExported { get; set; }

        //[JsonProperty("energy_imported")]
        //public string EnergyImported { get; set; }

        //[JsonProperty("instant_average_voltage")]
        //public string InstantAverageVoltage { get; set; }

        //[JsonProperty("instant_total_current")]
        //public string InstantTotalCurrent { get; set; }

        //[JsonProperty("i_a_current")]
        //public string IACurrent { get; set; }

        //[JsonProperty("i_b_current")]
        //public string IBCurrent { get; set; }

        //[JsonProperty("i_c_current")]
        //public string ICCurrent { get; set; }

        //[JsonProperty("timeout")]
        //public string Timeout { get; set; }
    }

    public class Solar
    {
        //[JsonProperty("last_communication_time")]
        //public string LastCommunicationTime { get; set; }

        [JsonProperty("instant_power")]
        public string InstantPower { get; set; }

        //[JsonProperty("instant_reactive_power")]
        //public string InstantReactivePower { get; set; }

        //[JsonProperty("instant_apparent_power")]
        //public string InstantApparentPower { get; set; }

        //[JsonProperty("frequency")]
        //public string Frequency { get; set; }

        //[JsonProperty("energy_exported")]
        //public string EnergyExported { get; set; }

        //[JsonProperty("energy_imported")]
        //public string EnergyImported { get; set; }

        //[JsonProperty("instant_average_voltage")]
        //public string InstantAverageVoltage { get; set; }

        //[JsonProperty("instant_total_current")]
        //public string InstantTotalCurrent { get; set; }

        //[JsonProperty("i_a_current")]
        //public string IACurrent { get; set; }

        //[JsonProperty("i_b_current")]
        //public string IBCurrent { get; set; }

        //[JsonProperty("i_c_current")]
        //public string ICCurrent { get; set; }

        //[JsonProperty("timeout")]
        //public string Timeout { get; set; }
    }
}
