using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using  Course.Entities.Enums;
using Course.Entities;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;

            Console.Write("Enter the departement's name:");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("BaseSalary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CI);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker?");
            int N = int.Parse(Console.ReadLine());

            for (int i =1; i <= N; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date (DD/MM/YYYY):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour:");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.WriteLine("Enter the month and year to calculate income (MM/YYY)");
            string MonthandYear = Console.ReadLine();

            int month = int.Parse(MonthandYear.Substring(0, 2));
            int year = int.Parse(MonthandYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departement: " + worker.Department.Name);
            Console.WriteLine("Income for " + MonthandYear + ": " + worker.Income(year, month));

            






        }
    }
}
