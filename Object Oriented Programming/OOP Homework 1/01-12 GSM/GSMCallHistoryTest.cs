using System;

namespace _01_12_GSM
{
    class GSMCallHistoryTest
    {
        public GSM phone;

        public GSMCallHistoryTest()
        {
            phone = new GSM("GalaxyAce", "Samsung", 450, 3.5f, 16000000, BatteryType.LiIon);
            phone.Owner = "Pesho Peshov"; // Pesho purchased Samsung
            phone.AddCall(359888888888, DateTime.Now, 230);
            phone.AddCall(359878878878, DateTime.Now - new TimeSpan(10, 20, 30), 30);
            phone.AddCall(359898898898, DateTime.Now - new TimeSpan(30, 20, 10), 63);
            phone.AddCall(359887887887, DateTime.Now - new TimeSpan(20, 30, 30), 123);
            phone.AddCall(359879879879, DateTime.Now - new TimeSpan(60, 60, 30), 96);
            phone.AddCall(359897897897, DateTime.Now - new TimeSpan(90, 60, 30), 83);
        }

        public override string ToString()
        {
            string result = "Testing CallHistory of GSM class...\r\n\r\n";
            result += phone.ToString() + "\r\n";
            return result;
        }
    }
}
