using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PCS.Models
{
    public class QualificationList
    {
        [Key]
        public int QualificationId { get; set; }
        public string QName { get; set; }

    }
}