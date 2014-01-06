using System;
using System.Collections.Generic;

namespace _01_12_GSM
{
    public class GSM
    {
        private static string _iPhone4SData;
        public static string IPhone4SData
        {
            get { return _iPhone4SData; }
            set
            {
                if (value.Length == 0) throw new ArgumentOutOfRangeException("Invalid GSMiPhone4SData"); // the iPhone4SData cannot be empty
                else _iPhone4SData = value;
            }
        }

        public Battery phoneBattery; // phone battery characteristics
        public Display phoneDisplay; // phone display characteristics

        private string _model; // phone model field
        public string Model { get {return _model;} } // phone model - readonly

        private string _manufacturer; // phone manufacturer field
        public string Manufacturer { get {return _manufacturer;} } // phone manufacturer - readonly

        public string Owner { get; set; } // current phone owner

        private decimal _price; // current phone price field 
        public decimal Price // current phone price property
        {
            get { return _price; }
            set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Invalid GSMPrice"); // the phone price cannot be less than 1.00 (EUR)
                else _price = value;
            }
        }

        public List<Call> CallHistory;

        public GSM()
            : this("iPhone4S", "Apple", 1000, 4.0f, 16000000, BatteryType.LiPoly)
        {
            IPhone4SData = "This phone is set by default";

        }

        public GSM(string model, string man, decimal price = 1, 
            float dispSize = 1, ulong dispCols = 2,
            BatteryType batType = BatteryType.Unknown, string batModel = "OEM")
        {
            this.phoneDisplay = new Display();
            this.phoneBattery = new Battery();
            this.CallHistory = new List<Call>();
            this._model = model;
            this._manufacturer = man;
            this.Price = price;
            this.Owner = ""; // the phone initially does not have an owner 
            if (dispSize - 1 > 0.001) this.phoneDisplay.SizeInches = dispSize; // sets the display size only if not default
            if (dispCols > 2) this.phoneDisplay.NrColors = dispCols; // sets the display colors only if not default
            if (batType != BatteryType.Unknown) this.phoneBattery.BatType = batType; // sets the battery type only if not default
            if (batModel != "OEM") this.phoneBattery.Model = batModel; // sets the battery model only if not default
        }

        public void AddCall(ulong phNumber, DateTime start, uint duration=Call.MinDuration) // adds a call to the history
        {
             this.CallHistory.Add(new Call(phNumber, start, duration));
        }

        public void RemoveCall() // removes the first call in the call history queue
        {
           this.RemoveCall(0);
        }
        
        public void RemoveCall(int index) // removes the call at the specified position in the call history queue
        {
            if (this.CallHistory.Count > 0 && index >= 0 && index < this.CallHistory.Count)
                this.CallHistory.Remove(this.CallHistory[index]);
        }

        public void ClearHistory()
        {
            while (this.CallHistory.Count > 0)
                this.RemoveCall();
        }

        public int FindLongestCall()
        {
            int index = -1;
            if (this.CallHistory.Count > 0)
            {
                index = 0;
                uint maxDuration = 0;
                for(int i=0; i < this.CallHistory.Count; i++)
	            {
                    if (this.CallHistory[i].Duration > maxDuration)
                    {
                        maxDuration = this.CallHistory[i].Duration;
                        index = i;
                    }
	            }     
            }            

            return index;
        }

        public decimal Bill(decimal pricePerMinute)
        {
            decimal sum = 0.0m;

            foreach (Call call in this.CallHistory)
            {
                sum += call.Duration * pricePerMinute / 60; // (each call duration / 60 seconds in minute) * price per minute
            }

            return sum;
        }

        public override string ToString()
        {
            string result = String.Format("GSM: model-{0}, manufacturer-{1}, price-{2:C2}\r\n", this.Model, this.Manufacturer, this.Price);
            if (this.Owner.Length > 0) result += String.Format("GSM Owner: {0}\r\n", this.Owner);
            result += String.Format("GSM Display: size-{0}\", number of colors-{1}\r\n", this.phoneDisplay.SizeInches,
                    this.phoneDisplay.NrColors);
            if (this.CallHistory.Count > 0)
            {
                result += "GSM Call History:\r\n";
                foreach (Call call in this.CallHistory)
	            {
                    result += String.Format("phone: 00{0}, date of call: {1:dd-MM-yy hh:mm}, duraton: {2}\r\n",
                        call.DialedPhone, call.CallStart, call.Duration);
                }
            }
            return result;
        }
    }
}
