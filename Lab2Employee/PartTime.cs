using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Employee
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hour;
        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        public double Hour
        {
            get { return hour; }
            set { hour = value; }
        }
        public PartTime() 
        { 
            
        }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hour) : base(id, name, address, phone, sin, dob, dept) 
        { 
            this.Rate = rate;
            this.Hour = hour;
        }

        public override double GetPay() 
        {
            return this.Rate * this.hour;
        }

        public override string ToString()
        {
            string formatted = "";
            formatted += "This is a part-time employee:\n";
            formatted += "Name: \t\t" + this.Name + "\n";
            formatted += "ID: \t\t" + this.Id + "\n";
            formatted += "Address: \t" + this.Address + "\n";
            formatted += "Phone: \t\t" + this.Phone + "\n";
            formatted += "SIN: \t\t" + this.Sin + "\n";
            formatted += "Date of birth: \t" + this.Dob + "\n";
            formatted += "Department: \t" + this.Dept + "\n";
            formatted += "Hourly rate: \t" + this.Rate + "\n";
            formatted += "Work hours: \t" + this.Hour + "\n";
            formatted += $"The pay for this employee in a week is: ${this.GetPay():F2}\n";


            return formatted;
        }
    }
}
