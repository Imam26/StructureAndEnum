using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees = 
            {
                new Employee("ЕМенеджеров", "Менеджер","менеджер",new DateTime(2012, 10, 21), 135000),
                new Employee("АМенеджеров", "Менеджер", "менеджер", new DateTime(2011, 09,22), 90000),
                new Employee("БМенеджеров","Менеджер", "менеджер", new DateTime(2014, 09,22), 60000),
                new Employee("АМенеджеров","Менеджер", "менеджер", new DateTime(2016, 09,22), 1400000),
                new Employee("СМенеджеров", "Менеджер", "менеджер", new DateTime(2013, 09,22), 100000),
                new Employee("ВКлерков", "Клерк1", "клерк", new DateTime(2015, 09,22), 80000),
                new Employee("СКлерков", "Клерк2", "клерк", new DateTime(2009, 09,22), 150000),
                new Employee("ЕКлерков", "Клерк3", "клерк", new DateTime(2010, 09,22), 60000),
                new Employee("АКлерков", "Клерк4", "клерк", new DateTime(2011, 09,22), 230000),
                new Employee("Босов", "Бос", "босс", new DateTime(2013, 09,22), 500000),
            };

            Console.WriteLine("************Задача 1*************");
            Console.WriteLine("Полная информация о сотрудниках: ");

            foreach(Employee tempEmployee in employees)
            {
                Console.WriteLine("----------------------");
                tempEmployee.Show();
            }

            Console.ReadKey();
            Console.Clear();

            double avarageSalary = employees.Where(x => x.Position == "клерк" ? true : false).Average(x => x.Salary);

            Console.WriteLine("************Задача 2*************");
            Console.WriteLine("Средняя заработная плата клерков: {0} тенге", avarageSalary);
            Console.WriteLine("Список менеджеров: ");

            var selectedManager = from employee in employees
                       where (employee.Position == "менеджер")&&
                       (employee.Salary>avarageSalary)
                       orderby employee.Surname
                       select employee;

            foreach(Employee tempEmployee in selectedManager)
            {
                Console.WriteLine("----------------------");
                tempEmployee.Show();
            }

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("************Задача 3*************");
            Console.WriteLine("Дата принятия босса на работу: 2013/09/22");
            Console.WriteLine("Список сотрудников: ");

            var selectedEmployees = from employee in employees
                                     where employee.DateOfEmployment > new DateTime(2013, 09, 22)
                                     orderby employee.Surname
                                     select employee;

            foreach(Employee tempEmployee in selectedEmployees)
            {
                Console.WriteLine("----------------------");
                tempEmployee.Show();
            }
        }
    }

    struct Employee
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public int Salary { get; set; }

        public Employee(string surname, string name, string position, DateTime date, int salary)
        {
            Surname = surname;
            Name = name;
            Position = position;
            DateOfEmployment = date;
            Salary = salary;
        }

        public void Show()
        {
            Console.WriteLine("Полное имя работника: {0} {1}", Surname, Name);
            Console.WriteLine("Должность: {0}", Position);
            Console.WriteLine("Дата приема на работу: {0}", DateOfEmployment);
            Console.WriteLine("Заработная плата: {0}  тенге", Salary);
        }
    }
}
