using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>()
            {
                new Student("Студент1", "группа1", 7.8, 30000, Sex.man, FormOfStudy.extramural),
                new Student("Студент2", "группа1", 7.9, 9000, Sex.man, FormOfStudy.extramural),
                new Student("Студент3", "группа1", 6.7, 12000, Sex.woman, FormOfStudy.extramural),
                new Student("Студент4", "группа2", 5.8, 18800, Sex.man, FormOfStudy.fullTime),
                new Student("Студент5", "группа2", 10, 6000, Sex.woman, FormOfStudy.fullTime),
                new Student("Студент6", "группа2", 8.1, 11500, Sex.man, FormOfStudy.fullTime),
                new Student("Студент7", "группа1", 8.8, 9200, Sex.woman, FormOfStudy.extramural),
            };

            int minSalary = 10000;

            Console.WriteLine("Размер двух минимальных зарплат: {0}", minSalary);
            Console.WriteLine("**********Порядок получения общежития: ");

            var firstQueue = studentList.Where(x => x.IncomePerFamilyMember < minSalary).OrderBy(x=>x.IncomePerFamilyMember);
            var secondQueue = studentList.Where(x => x.IncomePerFamilyMember > minSalary).OrderByDescending(x => x.AvarageScore);

            int number = 1;

            foreach(Student student in firstQueue.Concat(secondQueue))
            {
                Console.WriteLine("------------{0}-------------", number++);
                student.Show();
            }
        }
    }

    struct Student
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public double AvarageScore { get; set; }
        public int IncomePerFamilyMember { get; set; }
        public Sex StudentSex { get; set; }
        public FormOfStudy StudyForm { get; set; }

        public Student(string fullName, string group, double avarageScore, int income, Sex sex, FormOfStudy form)
        {
            FullName = fullName;
            Group = group;
            AvarageScore = avarageScore;
            IncomePerFamilyMember = income;
            StudentSex = sex;
            StudyForm = form;
        }

        public void Show()
        {
            Console.WriteLine("Полное имя студента: {0}", FullName);
            Console.WriteLine("Средний доход на члена семьи: {0}", IncomePerFamilyMember);
            Console.WriteLine("Средний балл: {0}", AvarageScore);
        }
    }

    enum Sex { man, woman };

    enum FormOfStudy { fullTime, extramural }

}
