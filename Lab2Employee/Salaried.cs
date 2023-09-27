using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Employee
{
    internal class Salaried : Employee
    {
        //Field
        private double salary;

        //Property
        public double Salary
        { 
            get { return salary; } set {  salary = value; } 
        }

        //Constructors
        public Salaried()
        {

        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        { 
            this.Salary = salary;
        }

        public override double GetPay()
        {
            return this.Salary;
        }

        public override string ToString()
        {
            string formatted = "";
            formatted += "This is a salaried employee:\n";
            formatted += "Name: \t\t" + this.Name + "\n";
            formatted += "ID: \t\t" + this.Id + "\n";
            formatted += "Address: \t" + this.Address + "\n";
            formatted += "Phone: \t\t" + this.Phone + "\n";
            formatted += "SIN: \t\t" + this.Sin + "\n";
            formatted += "Date of birth: \t" + this.Dob + "\n";
            formatted += "Department: \t" + this.Dept + "\n";
            formatted += "Salary: \t" + this.Salary + "\n";
            formatted += $"The pay for this employee in a week is: ${this.GetPay():F2}\n";

            return formatted;
        }
    }
}
