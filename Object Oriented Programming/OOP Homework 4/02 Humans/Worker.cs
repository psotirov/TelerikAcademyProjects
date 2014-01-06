using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Humans
{
    class Worker: Human
    {
        private decimal _weekSalary; // Week Salary holder
        private int _hoursPerWeek; // Working hours per Week holder
        // Hours per Day probably would be mistake since it leads to data inconsintency
        // How would be managed the case when someone is working 6 days per week while another only 3 days per week? 

        public Worker(string names, int payment = 500, int hours = 40)
            : base(names)
        {
            this.HoursPerWeek = hours; // standard working hours - 5 days * 8 hours per day
            this.WeekSalary = payment; // standard week salary - 500 (CNY) per week
        }

        public decimal WeekSalary // every Worker has a Week Salary -  a positive number
        {
            get {return this._weekSalary; }
            set
            {
                if ((value - 1.0m) < 0.01m) throw new ArgumentOutOfRangeException(); // the salary could not be less than 1.00
                this._weekSalary = value;
            }
        }

        public int HoursPerWeek // every Worker has a Work time - Working Hours per Week - a number between 1 and 72 (6 days * 12 hours)
        {
            get {return this._hoursPerWeek; }
            set
            {
                if (value < 1 || value > 72) throw new ArgumentOutOfRangeException();
                this._hoursPerWeek = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary/this.HoursPerWeek;
        }



        public override string GetKind()
        {
            return "Worker";
        }

        public override string ToString()
        {
            return String.Format ("{0} - Name: {1} {2}, Hourly salary: {3}",this.GetKind(), this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
