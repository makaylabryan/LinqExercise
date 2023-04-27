using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers   ---Thanks
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

            //TODO: Print the Sum of numbers   ---DONE
            var sum = numbers.Sum();
            Console.WriteLine($"Sum = {sum}");

            //TODO: Print the Average of numbers    ---DONE
            var average = numbers.Average();
            Console.WriteLine($"Average = {average}");

            //TODO: Order numbers in ascending order and print to the console  --DONE
            var ascendingOrder = numbers.OrderBy(x => x);
            Console.WriteLine("");
            foreach (var x in ascendingOrder)
            {
                Console.WriteLine(x);
            }

            //TODO: Order numbers in decsending order and print to the console   ---DONE
            var descendingOrder = numbers.OrderByDescending(num => num);
            Console.WriteLine("");
           foreach (var num in descendingOrder)
           { 
                Console.WriteLine(num); 
           }


            //TODO: Print to the console only the numbers greater than 6   ---DONE
            var aboveSix = numbers.Where(num => num > 6);
            Console.WriteLine("");
            foreach (var num in aboveSix)
            { 
                Console.WriteLine(num); 
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**   ---DONE
            Console.WriteLine("");
            var fourNums = numbers.Take(4).OrderBy(num => num);
            foreach (var num in fourNums)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("OR");
            var evens = numbers.Where(num => num % 2 == 0).Where(num => num > 0).OrderBy(num => num);
            foreach (var num in evens)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");
            
            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order    ---DONE
            numbers[4] = 27;
            foreach (var num in numbers.OrderByDescending(num => num)) 
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("");

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            Console.WriteLine($"C and S Employees:");

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C
            //OR an S and order this in ascending order by FirstName.   ---DONE
            var filterByLetter = employees.Where(person => person.FirstName[0] == 'C' || person.FirstName[0] =='S').
                OrderBy(person => person.FirstName);
            
            foreach (var employee in filterByLetter)
            { 
                Console.WriteLine($"{employee.FullName}"); 
            }
                Console.WriteLine("");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console
            //and order this by Age first and then by FirstName in the same result.    ---DONE
            var twentySix = employees.Where(person => person.Age > 26).OrderBy(person => person.Age).
                OrderBy(person => person.FirstName);
            Console.WriteLine("Name and Ages for those above 26:");
            foreach (var employee in twentySix)
            {
                Console.WriteLine($"{employee.FullName} {employee.Age}");
            }
            Console.WriteLine("");


            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35.   ---DONE
            var experience = employees.Where(person => person.Age > 35).Where(person => person.YearsOfExperience <= 10).ToList();

            var sumOfExperience = experience.Sum(employees => employees.YearsOfExperience);
            Console.WriteLine($"Sum of Experience:{sumOfExperience}");

            var avg = experience.Average(employees => employees.YearsOfExperience);
            Console.WriteLine($"Average years of Experience = {avg}");
            Console.WriteLine("");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Stefanie", "Colongo", 37, 5)).ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FullName}, {employee.Age}, {employee.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
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
