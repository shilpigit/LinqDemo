using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> DepList = new List<Department>()
            {
                new Department{ID=1,Name="IT" },
                new Department{ID=2,Name="Admin" }
            };
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID=1,Name="Shilpi", Department="IT", Designation="B",DepartmentID=1 });
            empList.Add(new Employee() { ID = 2, Name = "Shilpi1", Department = "IT", Designation = "A", DepartmentID = 1 });
            empList.Add(new Employee() { ID = 3, Name = "Shilpi2", Department = "IT", Designation = "B", DepartmentID = 1 });
            empList.Add(new Employee() { ID = 4, Name = "Shilpi3", Department = "IT", Designation = "B", DepartmentID = 2 });
            empList.Add(new Employee() { ID = 5, Name = "Shilpi4", Department = "IT", Designation = "Management", DepartmentID = 2 });
          
            //empList.Insert(0,new Employee { })

            string djfhjfd = 1.ToString();
            //var result = empList.Where(x => x.Designation == "B");

            IEnumerable iE = empList.Where(x => x.Designation == "B");//.OrderBy(x=>x.Designation).Take(2);

            var test = (from emp in empList
                        where emp.Designation == "B"
                        select emp).AsQueryable();

            if (true)
            {
                test = test.Take(2);
            }


           var iQ = empList.Where(x => x.Designation == "B").Take(2).OrderBy(x => x.Designation).ToList();//.AsQueryable();


            var res = empList.Where(x => x.Designation == "B").ToList();

            var test4 = empList.Where(x => x.Designation == "B").Select(x => x.Department);

            var test5 = empList.Where(x => x.Designation == "B").Select(x => new EmpModel
            {
                EmpDepartment = DepList.Where(y=>y.ID==x.DepartmentID).FirstOrDefault().Name,
                EmpDesignation = x.Designation,
                EmpID=x.ID,
                EmpName=x.Name
            }).ToList();

            //from linq

            var test6 = from emp in empList
                        join dep in DepList on emp.DepartmentID equals dep.ID
                        select new EmpModel
                        {
                            EmpDepartment = dep.Name,
                            EmpDesignation = emp.Designation,
                            EmpID = emp.ID,
                            EmpName = emp.Name
                        };
            var test7 = empList.Select(x =>
              {
                  if (x.Designation == "Management")
                  {
                      x.CustomText = "Welcome Sir,";
                  }
                  return x;
              });

            var anyRes = empList.Any(x => x.Name == "Shilpi");
        }
    }
    class EmpModel
    {
        public int EmpID;
        public string EmpName;
        public string EmpDepartment;
        public string EmpDesignation;
    }
    class Employee
    {
        public int ID;
        public string Name;
        public string Department;
        public int DepartmentID { get; set; }
        public string Designation;
        public string CustomText { get; set; }
    }
}
