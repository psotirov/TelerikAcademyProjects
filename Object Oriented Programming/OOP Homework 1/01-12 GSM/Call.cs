using System;

namespace _01_12_GSM
{
    public class Call
    {
        public const uint MinDuration = 60;  // by default first 60 seconds of the call counts as a whole minute even the actual duration is less 
        public DateTime CallStart { get; set; } // date and time of call start
        public ulong DialedPhone { get; set; } // dialed phone number incl. int. prefix code, no leading zeros, for example 359888888888
        public uint Duration { get; set; } // call duraton in seconds, for example 60

        public Call()
            : this(0, DateTime.Now, MinDuration)
        {
        }

        public Call(ulong phNumber, DateTime start, uint duration)
        {
            if (duration < MinDuration) duration = MinDuration;
            this.CallStart = start; // sets the start time of the call
            this.DialedPhone = phNumber; // sets the dialed phone number
            this.Duration = duration; // sets the call duraton
        }
    }
}
