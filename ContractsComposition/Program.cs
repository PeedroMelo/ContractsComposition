using System;
using System.Globalization;
using ContractsComposition.Entities;
using ContractsComposition.Entities.Enums;

namespace ContractsComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the department name: ");
            string departamento = Console.ReadLine();

            Console.WriteLine("Worker Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(departamento);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                worker.AddContract(
                    new HourContract(date, valuePerHour, hours)
                );
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate de income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year  = int.Parse(monthAndYear.Substring(3));
            double income = worker.Income(year, month);

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {income.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}
