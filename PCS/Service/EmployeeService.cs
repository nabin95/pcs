using PCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCS.Service
{
    public class EmployeeService
    {
        EmployeeDBContext emp = new EmployeeDBContext();
        public IEnumerable<QualificationList> GetQualifiction()
        {
            return emp.QualificationLists.ToList();
        }
        public bool SaveEmployee(Employee empl)
        {

            emp.Employees.Add(empl);
            return emp.SaveChanges() > 0;
        }
        public bool SaveQualification(EmpQualification qu)
        {
            emp.Qualifications.Add(qu);
            return emp.SaveChanges() > 0;
        }
        public bool UpdateQualification(EmpQualification qu)
        {
            emp.Entry(qu).State = System.Data.Entity.EntityState.Modified;
            return emp.SaveChanges() > 0;
        }
        public bool UpdateEmployee(Employee employee)
        {
            emp.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            return emp.SaveChanges() > 0;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return emp.Employees.ToList();
        }
    }
}