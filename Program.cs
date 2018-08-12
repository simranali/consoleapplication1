using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> em = new List<Employee>(){
                  new Employee(){ ID = 1, FullName = "Haziq", Age = 5, DepartmentID = 12}
                 ,new Employee(){ ID=2,FullName="Iba", Age=3, DepartmentID=14}
                 ,new Employee(){ ID=3, FullName="Shahzain", Age=6, DepartmentID=16}
            };

            List<Department> dp = new List<Department>(){
                new Department(){ ID = 14, DepartmentName = "IBA Department"}
                , new Department(){ID=12, DepartmentName = "Haziq Department"}
            };

            var result = em.Join(dp, e => e.DepartmentID, d => d.ID, (employee, department) => new
            {
                EmployeeName = employee.FullName,
                DepartmentName = department.DepartmentName
            });

            var result1 = em.GroupJoin(dp, e => e.DepartmentID, d => d.ID,
                                        (emp, dep) => new { emp, dep }).SelectMany(z => z.dep.DefaultIfEmpty(),
                                        (a, b) => new { empName = a.emp.FullName, departmentName = b == null ? "No Deparmtment" : b.DepartmentName }
                            );


            foreach (var e in result1)
            {
                Console.WriteLine("{0}  {1}", e.empName, e.departmentName);
            }
            Console.ReadLine();

            foreach (var e in result)
            {
                Console.WriteLine("{0}  {1}", e.EmployeeName, e.DepartmentName);
            }
            Console.ReadLine();
        }
    }
}
