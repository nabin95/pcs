using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PCS.Models
{
    public class EmpQualification
    {
        [Key]
        public int QulId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("QualificationList")]
        public int QualificationId { get; set; }
        public virtual Employee Employee { get; set; }



        public virtual QualificationList QualificationList { get; set; }
        public float Marks { get; set; }
    }
}