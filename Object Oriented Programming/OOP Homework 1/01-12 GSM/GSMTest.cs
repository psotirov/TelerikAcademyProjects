using System;
using System.Collections.Generic;

namespace _01_12_GSM
{
    public class GSMTest
    {
        public List<GSM> phones;

        public GSMTest()
        {
            phones = new List<GSM>();
            phones.Add(new GSM());
            phones.Add(new GSM("GalaxyAce", "Samsung", 450, 3.5f, 16000000, BatteryType.LiIon));
            phones.Add(new GSM("Lumia", "Nokia", 900, 4.0f, 16000000, BatteryType.LiIon));
            phones.Add(new GSM("1000", "Nokia", 50));
            phones.Add(new GSM("Asha", "Nokia", 100, 3.0f));
            phones[0].Owner = "Pesho Peshov"; // Pesho purchased iPhone
            phones[3].Owner = "Miko Mikov"; // Miko purchased Nokia 1000
            GSM.IPhone4SData = "Some iPhone 4S data";
        }

        public override string ToString()
        {
            string result = "Testing GSM class...\r\n\r\n";
            foreach (GSM item in phones)
            {
                result += item.ToString() + "\r\n";
            }
            result += "\r\nStatic member IPhone4SData = " + GSM.IPhone4SData + "\r\n\r\n";
            return result;
        }
    }
}
