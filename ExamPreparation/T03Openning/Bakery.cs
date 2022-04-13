using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
    
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        //public List<Employee> Data
        //{
        //    get { return data; }
        //    set { data = value; }
        //}
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employeeToRemove = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(employeeToRemove);
        }

        public Employee GetOldestEmployee()
        {
            Employee oldestEmployee = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(x => x.Name == name);
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (Employee employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
