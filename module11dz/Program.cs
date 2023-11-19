using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inter;

namespace module11dz
{
    class Program
    {
        static void Main()
        {
            Console.Write("Количество сотрудников: ");
            int employeeCount = int.Parse(Console.ReadLine());

            Employee[] employees = new Employee[employeeCount];

            for (int i = 0; i < employeeCount; i++)
            {
                employees[i] = CreateEmployee();
            }
            Console.ReadLine();
        }

        static Employee CreateEmployee()
        {
            Console.Write("Имя: ");
            string firstName = Console.ReadLine();

            Console.Write("Фамилию: ");
            string lastName = Console.ReadLine();

            Console.Write("Должность: ");
            string position = Console.ReadLine();

            Console.Write("Зарплату: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("Пол Male/Female: ");
            Gender gender = (Gender)Enum.Parse(typeof(Gender), Console.ReadLine(), true);

            Console.Write("Дата принятия на работу (гггг-мм-дд): ");
            DateTime hireDate = DateTime.Parse(Console.ReadLine());

            return new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Position = position,
                Salary = salary,
                Gender = gender,
                HireDate = hireDate
            };
        }

        static void PrintAllEmployeesInfo(Employee[] employees)
        {
            Console.WriteLine("Полная информация о всех сотрудниках:");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.GetFullInfo());
            }
        }

        static void PrintEmployeesByPosition(Employee[] employees, string position)
        {
            Console.WriteLine($"Информация о сотрудниках на должности {position}:");
            foreach (var employee in employees.Where(e => e.Position.Equals(position, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine(employee.GetFullInfo());
            }
        }

        static void PrintHighSalaryManagers(Employee[] employees)
        {
            var clerksSalary = employees.Where(e => e.Position.Equals("Clerk", StringComparison.OrdinalIgnoreCase)).Average(e => e.Salary);
            var highSalaryManagers = employees.Where(e => e.Position.Equals("Manager", StringComparison.OrdinalIgnoreCase) && e.Salary > clerksSalary)
                                              .OrderBy(e => e.LastName);

            Console.WriteLine($"Информация о менеджерах с зарплатой выше средней зарплаты клерков:");
            foreach (var manager in highSalaryManagers)
            {
                Console.WriteLine(manager.GetFullInfo());
            }
        }

        static void PrintEmployeesHiredAfterDate(Employee[] employees, DateTime hireDate)
        {
            var hiredAfterDate = employees.Where(e => e.HireDate > hireDate)
                                          .OrderBy(e => e.LastName);

            Console.WriteLine($"Информация о сотрудниках, принятых на работу позже {hireDate.ToShortDateString()}:");
            foreach (var employee in hiredAfterDate)
            {
                Console.WriteLine(employee.GetFullInfo());
            }
        }

        static void PrintEmployeesByGender(Employee[] employees, Gender gender)
        {
            var employeesByGender = employees.Where(e => e.Gender == gender)
                                            .OrderBy(e => e.LastName);

            Console.WriteLine($"Информация о {(gender == Gender.Male ? "мужчинах" : "женщинах")}:");
            foreach (var employee in employeesByGender)
            {
                Console.WriteLine(employee.GetFullInfo());
            }
        }
    }
}
