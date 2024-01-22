using System;

namespace SortByName
{
    struct Student
    {
        public string Name;
        public double Grade;

        public Student(string name, double grade)
        {
            this.Name = name;
            this.Grade = grade;
        }
    }

    class Program
    {
        static void Main()
        {
            Student[] students = ReadStudents();
            QuickSort(students);
            Print(students);
            Console.Read();
        }

        static void QuickSort(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (Compara(students[i], students[j]))
                    {
                        Student temp = students[i];
                        students[i] = students[j];
                        students[j] = temp;
                    }
                }
            }
        }

        static bool Compara(Student a, Student b)
        {
            bool result = false;

            for (int i = 0; i < a.Name.Length && i < b.Name.Length; i++)
            {
                if (a.Name[i] > b.Name[i])
                {
                    result = true;
                    return result;
                }
                else if (a.Name[i] < b.Name[i])
                {
                    return result;
                }
            }

            return result;
        }

        static void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(string.Format("{0}: {1:F2}", students[i].Name, students[i].Grade));
            }
        }

        static Student[] ReadStudents()
        {
            int studentsNumber = Convert.ToInt32(Console.ReadLine());
            Student[] result = new Student[studentsNumber];

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] studentData = Console.ReadLine().Split(':');
                result[i] = new Student(studentData[0], Convert.ToDouble(studentData[1]));
            }

            return result;
        }
    }
}
