using Course_Entities.Entities;
using Course_Entities.Entities.Enums;
using System.Globalization;

namespace Course_Entities // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptNameAux = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string nameAux = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double basSalaryAux = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dpt = new Department(deptNameAux);
            Worker worker = new Worker(nameAux, level, basSalaryAux, dpt);

            Console.Write("How many contracts to this worker? ");
            int contratNumbersAux = int.Parse(Console.ReadLine());

            for(int i = 0; i < contratNumbersAux; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contractAux = new HourContract(date, valuePerHour, hours);

                worker.AddContract(contractAux);
            }

            Console.WriteLine();
            
            Console.Write("Enter month and year to calculate income (MM/YYY): ");
            
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year,month).ToString("f2", CultureInfo.InvariantCulture)}");
        }
    }
}