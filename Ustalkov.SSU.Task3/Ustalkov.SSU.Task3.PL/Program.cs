using System;
using System.Collections.Generic;
using System.Linq;
using Ustalkov.SSU.Task3.Entity;
using Ustalkov.SSU.Task3.BL;

namespace Ustalkov.SSU.Task3.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            IAwardLogic awardLogic = new AwardLogic();
            IEmployeeLogic employeeLogic = new EmployeeLogic();

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Award");
                Console.WriteLine("3. Exit");
                Console.WriteLine();

                int decision;
                int second_decision;
                if (int.TryParse(Console.ReadLine(), out decision))
                {
                    switch (decision)
                    {
                        case 1:
                            Console.WriteLine("1. Show all");
                            Console.WriteLine("2. Add new employee");
                            Console.WriteLine("3. Delete employee by id");
                            Console.WriteLine("4. Add new award for employee");
                            Console.WriteLine("5. Exit");

                            if (int.TryParse(Console.ReadLine(), out second_decision))
                            {
                                switch (second_decision)
                                {
                                    case 1:
                                        List<Employee> employees = employeeLogic.SelectEmployee();

                                        foreach (var item in employees)
                                        {
                                            Console.Write($"ID employee: {item.Id}, ");
                                            Console.Write($"name: {item.Name}, ");
                                            Console.Write($"date of birth: {item.DateOfBirth}, ");
                                            Console.Write($"age: {item.Age}, ");
                                            if (item.Awards.Count > 0)
                                            {
                                                Console.WriteLine("awards:");
                                                foreach (var award in item.Awards)
                                                {
                                                    Console.Write($"ID award: {award.Id}, ");
                                                    Console.WriteLine($"award title: {award.Title}");
                                                }
                                                Console.WriteLine();
                                            }
                                            else
                                            {
                                                Console.WriteLine();
                                            }
                                        }
                                        break;
                                    case 2:
                                        string name;
                                        DateTime dateOfBirth;
                                        int age;

                                        Console.Write("Press name: ");
                                        name = Console.ReadLine();

                                        Console.Write("Press date of birth (DD.MM.YYYY): ");
                                        List<int> date = Console.ReadLine().Split('.').
                                            Select(x => int.Parse(x)).ToList();
                                        dateOfBirth = new DateTime(date[2], date[1], date[0]);

                                        Console.Write("Press age: ");
                                        age = int.Parse(Console.ReadLine());

                                        Console.WriteLine(employeeLogic.InsertIntoEmployee(name, dateOfBirth, age));
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        int id;

                                        Console.Write("Press id: ");
                                        id = int.Parse(Console.ReadLine());

                                        Console.WriteLine(employeeLogic.DeleteEmployee(id));
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        int idAward;
                                        int idEmployee;

                                        Console.Write("Press award id: ");
                                        idAward = int.Parse(Console.ReadLine());

                                        Console.Write("Press employee id: ");
                                        idEmployee = int.Parse(Console.ReadLine());

                                        Console.WriteLine(employeeLogic.AddAwardForEmployee(idEmployee, idAward));
                                        Console.WriteLine();
                                        break;
                                    case 5:
                                        break;
                                    default:
                                        Console.WriteLine("Wrong number!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not a number!");
                            }
                            break;
                        case 2:
                            Console.WriteLine("1. Show all");
                            Console.WriteLine("2. Add new award");
                            Console.WriteLine("3. Delete award by id");
                            Console.WriteLine("4. Exit");

                            if (int.TryParse(Console.ReadLine(), out second_decision))
                            {
                                switch (second_decision)
                                {
                                    case 1:
                                        List<Award> awards = awardLogic.SelectAward();

                                        foreach (var item in awards)
                                        {
                                            Console.Write($"ID: {item.Id}, ");
                                            Console.WriteLine($"Title: {item.Title}");
                                        }
                                        Console.WriteLine();
                                        break;
                                    case 2:
                                        string title;

                                        Console.Write("Press title: ");
                                        title = Console.ReadLine();

                                        Console.WriteLine(awardLogic.InsertIntoAward(title));
                                        Console.WriteLine();
                                        break;
                                    case 3:
                                        int id;

                                        Console.Write("Press id: ");
                                        id = int.Parse(Console.ReadLine());

                                        Console.WriteLine(awardLogic.DeleteAward(id));
                                        Console.WriteLine();
                                        break;
                                    case 4:
                                        break;
                                    default:
                                        Console.WriteLine("Wrong number!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is not a number!");
                            }
                            break;
                        case 3:
                            isRunning = false;
                            break;
                        default:
                            Console.WriteLine("Wrong number!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("It is not a number!");
                }
            }
        }
    }
}
