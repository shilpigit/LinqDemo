using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID=1,Name="Shilpi", Department="IT", Designation="B" });
            empList.Add(new Employee() { ID = 2, Name = "Shilpi1", Department = "IT", Designation = "A" });
            empList.Add(new Employee() { ID = 3, Name = "Shilpi2", Department = "IT", Designation = "B" });
            empList.Add(new Employee() { ID = 4, Name = "Shilpi3", Department = "IT", Designation = "B" });
            empList.Add(new Employee() { ID = 5, Name = "Shilpi4", Department = "IT", Designation = "C" });


            //var result = empList.Where(x => x.Designation == "B");

            IEnumerable iE = empList.Where(x => x.Designation == "B").OrderBy(x=>x.Designation).Take(2);


            IQueryable iQ = empList.Where(x => x.Designation == "B").Take(2).OrderBy(x => x.Designation).AsQueryable();


            var res = empList.Where(x => x.Designation == "B").ToList();
            var anyRes = empList.Any(x => x.Name == "Shilpi");
        }
    }

    class Employee
    {
        public int ID;
        public string Name;
        public string Department;
        public string Designation;
    }
}
