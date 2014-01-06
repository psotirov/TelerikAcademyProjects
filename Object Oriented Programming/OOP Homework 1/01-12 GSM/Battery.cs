using System;

public enum BatteryType { NiCd, NiMH, LiIon, LiPoly, Unknown } 

namespace _01_12_GSM
{
    public class Battery
    {
        public BatteryType BatType { get; set; } // GSM battery type property, for example LiIon (Unknown by default)
        public string Model { get; set; } // GSM battery model property, for example "ANSMANN" ("OEM" by default)
        private float _hoursIdle; // battery hours in idle mode field
        private float _hoursTalk; // battery hours in talking mode field

        public float HoursIdle // battery hours in idle mode property
        {
            get { return _hoursIdle; }
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Invalid BatteryIdleHours"); // the idle hours cannot be negative
                else _hoursIdle = value;
            }
        }
        public float HoursTalk // battery hours in talking mode property
        {
            get { return _hoursTalk; }
            set 
            {
                if (value < 0) throw new ArgumentOutOfRangeException("Invalid BatteryTalkHours"); // the talk hours cannot be negative
                else _hoursTalk = value;
            }
        }
        public Battery(string model = "OEM", BatteryType batType = BatteryType.Unknown, float ih = 0, float th = 0)
        {
            this.Model = model;
            this.BatType = batType;
            this.HoursIdle = ih;
            this.HoursTalk = th;
        }
    }
}
