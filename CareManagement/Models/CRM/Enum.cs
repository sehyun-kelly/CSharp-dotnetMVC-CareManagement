using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareManagement.Models.CRM
{
    public class Enum
    {
        public enum ApplianceType
        {
            Stove,
            Fridge,
            Microwave,
            Toaster,
            Kettle
        }

        public enum ApplianceBrand
        {
            LG,
            Bosch,
            GE,
            Samsung,
            Electrolux
        }

        public enum AssetType
        {
            Suite,
            ParkingLot,
            Locker
        }
    }
}
