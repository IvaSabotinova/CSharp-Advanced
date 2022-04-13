using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace ClassroomProject
{
    public class Classroom
    {
        public int Capacity { get; set; }
        public int Count => Students.Count;
        public List<Student> Students { get; set; }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            StringBuilder sb = new StringBuilder();
            if (Count < Capacity)
            {
                Students.Add(student);
                return sb.Append($"Added student {student.FirstName} {student.LastName}").ToString();
            }
            return sb.Append("No seats in the classroom").ToString();
        }

        public string DismissStudent(string firstName, string lastName)
        {
            StringBuilder sb = new StringBuilder();
            if (Students.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Student studentToRemove =
                    Students.First(x => x.FirstName == firstName && x.LastName == lastName);
                Students.Remove(studentToRemove);
                return sb.Append($"Dismissed student {studentToRemove.FirstName} {studentToRemove.LastName}").ToString();
            }

            return sb.Append("Student not found").ToString();
        }

        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            if (Students.Any(x => x.Subject == subject))
            {
                List<Student> studentWithThisSubject = Students.FindAll(x => x.Subject == subject);
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (Student student in studentWithThisSubject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return Students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            StringBuilder sb = new StringBuilder();
            Student student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }

    }
}
