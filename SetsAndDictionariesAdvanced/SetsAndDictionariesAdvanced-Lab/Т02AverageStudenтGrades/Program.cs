using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;


namespace Т02AverageStudenтGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> allStudents_Grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currentStudentName = data[0];
                decimal currentGrade = decimal.Parse(data[1]);

                if (!allStudents_Grades.ContainsKey(currentStudentName))
                {
                    allStudents_Grades.Add(currentStudentName, new List<decimal>());
                }
                allStudents_Grades[currentStudentName].Add(currentGrade);
            }

            foreach (KeyValuePair<string, List<decimal>> student in allStudents_Grades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x=>x.ToString("f2")))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
