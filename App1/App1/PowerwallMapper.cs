using App1.Models;
using System;
using System.Linq;

namespace App1
{
    public class PowerwallMapper : IPowerwallMapper
    {
        /// <summary>
        /// Converts the unserialisably long decimals from the Powerwall into ints.
        /// </summary>
        /// <param name="powerwallString"></param>
        /// <returns></returns>
        internal int StringToInt(string powerwallString)
        {
            if (string.IsNullOrWhiteSpace(powerwallString))
            {
                return 0;
            }

            var truncated = powerwallString.Split('.')?.FirstOrDefault();

            return int.TryParse(truncated, out int result) ? result : 0;
        }

        /// <returns>watts as kilowatts rounded to 1 decimal place</returns>
        internal decimal WattsToKiloWatts(int watts)
        {
            return Math.Round((decimal)watts, 1);
        }

        public PowerwallStatus Map(Aggregates aggregates, Soe soe)
        {
            return new PowerwallStatus
            {
                Battery = WattsToKiloWatts(StringToInt(aggregates?.Battery?.InstantPower)),
                Grid = WattsToKiloWatts(StringToInt(aggregates?.Site?.InstantPower)),
                Home = WattsToKiloWatts(StringToInt(aggregates?.Load?.InstantPower)),
                Solar = WattsToKiloWatts(StringToInt(aggregates?.Solar?.InstantPower)),
                BatteryCharge = StringToInt(soe.Percentage),
            };
        }
    }
}
