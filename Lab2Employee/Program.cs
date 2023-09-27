using System.Collections.Generic;
using System.Xml.Linq;

namespace Lab2Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("employees.txt");
            List<Employee> employees = new List<Employee>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(":");

                string id = columns[0];
                string name = columns[1];
                string address = columns[2];
                string phone = columns[3];
                long sin = long.Parse(columns[4]);
                string dob = columns[5];
                string dept = columns[6];

                char firstDigitOfId = id[0];

                if (firstDigitOfId == '0' || firstDigitOfId == '1' || firstDigitOfId == '2' || firstDigitOfId == '3' || firstDigitOfId == '4')
                {
                    double salary = double.Parse(columns[7]);
                    //create the Salaried object
                    Salaried salaried = new Salaried(id, name, address, phone, sin, dob, dept, salary);

                    //add salaried to employees
                    employees.Add(salaried);
                }

                if (firstDigitOfId == '5' || firstDigitOfId == '6' || firstDigitOfId == '7')
                {
                    double rate = double.Parse(columns[7]);
                    double hour = double.Parse(columns[8]);
                    //create the Wages object
                    Wages wages = new Wages(id, name, address, phone, sin, dob, dept, rate, hour);
                    //add to employees
                    employees.Add(wages);
                }

                if (firstDigitOfId == '8' || firstDigitOfId == '9')
                {
                    double rate = double.Parse(columns[7]);
                    double hour = double.Parse(columns[8]);
                    //create the PartTime object
                    PartTime partTime = new PartTime(id, name, address, phone, sin, dob, dept, rate, hour);
                    //add to employees
                    employees.Add(partTime);
                }
            }


            //calculate the average weekly pay for all employees
            double averageWeeklyPay = CalculateAverageWeeklyPay(employees);
            Console.WriteLine($"The average weekly pay for all employees is: ${averageWeeklyPay:F2}\n");

            string highestSalaryForWages = CalculateHighestWeeklyPayForWages(employees);
            Console.WriteLine(highestSalaryForWages);

            string lowestSalaryForSalaried = CalculateLowestWeeklyPayForSalaried(employees);
            Console.WriteLine(lowestSalaryForSalaried);

            Console.WriteLine("");

            PercentageOfEmployees(employees);
        }


        // method for calculating average weekly pay for all employees
        public static double CalculateAverageWeeklyPay(List<Employee> employees)
        {
            double totalWeeklyPay = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    //calculate the weekly pay for Salaried employee
                    double salary = employee.GetPay();

                    totalWeeklyPay += salary;                 

                    //display the information of the employee
                    Console.WriteLine(employee.ToString());

                }
                if (employee is Wages)
                {
                    //calculate the weekly pay for Wages employee
                    double wage = employee.GetPay();


                    totalWeeklyPay += wage;

                    //display the information of the employee
                    Console.WriteLine(employee.ToString());
                }
                if (employee is PartTime )
                {
                    //calculate the weekly pay for PartTime employee
                    double partTimePay = employee.GetPay();

                    totalWeeklyPay += partTimePay;

                    //display the information of the employee
                    Console.WriteLine(employee.ToString());
                }
            }

            Console.WriteLine($"The total monthly salary expenditure amount is: ${totalWeeklyPay:F2}");
            double averageWeeklyPay = totalWeeklyPay / employees.Count;
            return averageWeeklyPay;
        }


        // method for calculating the highest weekly pay for wages employees
        static string CalculateHighestWeeklyPayForWages(List<Employee> employees)
        {
            double highestWage = 0;
            string name = "";
            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    double wagePay = employee.GetPay();

                    if (wagePay > highestWage)
                    {
                        highestWage = wagePay;
                        name = employee.Name;
                    }
                }
            }

            return $"The highest salary for the wage emloyees is ${highestWage} for {name}.";
        }


        // method for calculating the lowest weekly pay for salaried employees
        static string CalculateLowestWeeklyPayForSalaried(List<Employee> employees)
        {
            string name = "";
            double lowestSalary = 1000000;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    double salary = employee.GetPay();

                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        name = employee.Name;
                    }
                }
            }
            return $"The lowest salary for the salaried emloyees is ${lowestSalary} for {name}.";
        }


        // method for calculating the percentage of employees fall into each employee category
        static void PercentageOfEmployees(List<Employee> employees)
        {
            double numberOfSalaried = 0;
            double numberOfWages = 0;
            double numberOfPartTime = 0;

            //calculate the number of employees in different categories
            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    numberOfSalaried += 1;
                }
                if (employee is Wages)
                {
                    numberOfWages += 1;
                }
                if (employee is PartTime)
                {
                    numberOfPartTime += 1;
                }
            }


            //calculate the percentage of the employees in each category
            double percentOfSalaried = numberOfSalaried / employees.Count * 100;
            double percentOfWages = numberOfWages / employees.Count * 100;
            double percentOfPartTime = numberOfPartTime / employees.Count * 100;

            string percentageOfSalaried = string.Format("{0:F2}", percentOfSalaried);
            string percentageOfWages = string.Format("{0:F2}", percentOfWages);
            string percentageOfPartTime = string.Format("{0:F2}", percentOfPartTime);

            Console.WriteLine("The percentage of company's employees fall into Salaried is: " + percentageOfSalaried + "%");
            Console.WriteLine("The percentage of company's employees fall into Wages is: " + percentageOfWages + "%");
            Console.WriteLine("The percentage of company's employees fall into PartTime is: " + percentageOfPartTime + "%");
        }

    }
}