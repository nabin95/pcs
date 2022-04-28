using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCS.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        public string EmpName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime EntryDate { get; set; }
    }
    public class EmployeeActionModel
    {
        public int EmployeeId { get; set; }
        public string EmpName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public decimal Salary { get; set; }
        public string Entry_By { get; set; }
        public DateTime EntryDate { get; set; }
        public int QualificationId { get; set; }
        public QualificationList Qulist { get; set; }
        public EmpQualification Qualifications { get; set; }
        public float Marks { get; set; }
        public IEnumerable<QualificationList> QuLists { get; set; }
        public IEnumerable<Employee> EmpList { get; set; }

    }
}