using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers - DONE!

            Console.WriteLine("Sum of the list:");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("");

            //TODO: Print the Average of numbers - DONE!

            Console.WriteLine("Average of the list:");
            Console.WriteLine(numbers.Average());
            Console.WriteLine("");

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("List in asending order:");
            var aOrder = numbers.OrderBy(x => x);

            foreach (var number in aOrder) { Console.WriteLine(number); }
            Console.WriteLine("");

            //TODO: Order numbers in decsending order and print to the console

            Console.WriteLine("List in descending order:");
            var dOrder = numbers.OrderByDescending(x => x);

            foreach (var number in dOrder) { Console.WriteLine(number); }
            Console.WriteLine("");

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers in the list that are greater than six:");
            var aboveSix = numbers.Where(x => x > 6);
            foreach (var number in aboveSix) { Console.WriteLine(number); }
            Console.WriteLine("");

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("4 random ascending numbers from the list:");

            foreach (var n in aOrder.Take(4))
            { Console.WriteLine(n); }
            Console.WriteLine("");

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            Console.WriteLine("Adding my age to index 4 and writing the list numbers in descending order:");
            numbers.SetValue(22, 4);
            var dAge = numbers.OrderByDescending(x => x);
            foreach (var number in dAge) { Console.WriteLine(number); }
            Console.WriteLine("");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("Employees that start with an c or s in order:");

            var fNameIsCOrS = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower()[0] == 's').OrderBy(person => person.FirstName);

            var aFNameIsCorS = employees.FindAll(name => name.FirstName.ToLower()[0] == 'c' || name.FirstName.ToLower()[0] == 's').OrderBy(name => name.FirstName);

            foreach (var person in fNameIsCOrS)
            { Console.WriteLine(person.FirstName); }

            Console.WriteLine("");



            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Employees over the age of 26:");
            var twentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);

            foreach (var age in twentySix)
            { Console.WriteLine($"Employee Name: {age.FullName}, Employee Age: {age.Age}");

                Console.WriteLine("");

                //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

                Console.WriteLine("Employees YOE Sum and Average:");

                var YOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);

                Console.WriteLine($"Total YOE:{YOE.Sum(x => x.YearsOfExperience)}");
                Console.WriteLine($"Avg YOE:{YOE.Average(x => x.YearsOfExperience)}");

                Console.WriteLine("");

                //TODO: Add an employee to the end of the list without using employees.Add()

                Console.WriteLine("Adding and employee to the list without using .add():");

                employees = employees.Append(new Employee("First", "Last", 30, 10)).ToList();

                employees.Add(new Employee("Bob", "The Builder", 40, 5));

                foreach (var employee in employees) { Console.WriteLine(employee.FullName); }

                Console.WriteLine();

                Console.ReadLine();
            }

        
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
