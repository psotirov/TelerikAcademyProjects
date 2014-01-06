using System;

namespace AnotherCodeFragment
{
    class HumanBeing
    {
        enum GenderEnum { Male, Female };

        struct HumanStruct
        {
            public GenderEnum Gender { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public HumanStruct Human { get; set; }

        public HumanBeing(int age)
        {
            Human = new HumanStruct();
            Human.Age = age;
            if (age % 2 == 0)
            {
                Human.Name = "Batkata";
                Human.Gender = GenderEnum.Male;
            }
            else
            {
                Human.Name = "Matseto";
                Human.Gender = GenderEnum.Female;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
