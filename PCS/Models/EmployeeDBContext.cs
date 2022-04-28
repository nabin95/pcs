using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCS.Models
{
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext()
        : base("MainConnection")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<QualificationList> QualificationLists { get; set; }

        public DbSet<EmpQualification> Qualifications { get; set; }
    }
}