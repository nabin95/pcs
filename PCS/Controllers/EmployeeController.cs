using PCS.Models;
using PCS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PCS.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService empService = new EmployeeService();

        public ActionResult Index()
        {
            EmployeeActionModel model = new EmployeeActionModel();
            model.QuLists = empService.GetQualifiction();
            model.EmpList = empService.GetEmployees();
            return View(model);
        }

        public JsonResult SaveEmployee(EmployeeActionModel employee, string d)
        {
            JsonResult json = new JsonResult();
            var result = false;
            Employee emp = new Employee();
            employee.EmployeeId = 4;
            if (employee.EmployeeId != 0)
            {
                emp.EmployeeId = 4;
                emp.EmpName = employee.EmpName;
                emp.DOB = employee.DOB;
                emp.Gender = employee.Gender;
                emp.Salary = employee.Salary;
                emp.Entry_By = "Saroj";
                emp.EntryDate = DateTime.Now;
                result = empService.UpdateEmployee(emp);

                EmpQualification qu = new EmpQualification();
                JavaScriptSerializer serializers = new JavaScriptSerializer();
                JavaScriptSerializer j = new JavaScriptSerializer();
                List<EmployeeActionModel> empl = new JavaScriptSerializer().Deserialize<List<EmployeeActionModel>>(d);
                for(int i = 0; i < empl.Count; i++)
                {
                    qu.QulId = 4;
                    qu.EmployeeId = emp.EmployeeId;
                    qu.Marks = empl[i].Marks;
                    qu.QualificationId = empl[i].QualificationId;
                    empService.UpdateQualification(qu);
                }


            }
            else
            {
                emp.EmployeeId = employee.EmployeeId;
                emp.EmpName = employee.EmpName;
                emp.DOB = employee.DOB;
                emp.Gender = employee.Gender;
                emp.Salary = employee.Salary;
                emp.Entry_By = "Nabin";
                emp.EntryDate = DateTime.Today;

                result = empService.SaveEmployee(emp);
                EmpQualification q = new EmpQualification();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<EmployeeActionModel> target = new JavaScriptSerializer().Deserialize<List<EmployeeActionModel>>(d);
                for (int i = 0; i < target.Count; i++)
                {

                    q.EmployeeId = emp.EmployeeId;
                    q.Marks = target[i].Marks;
                    q.QualificationId = target[i].QualificationId;
                    empService.SaveQualification(q);

                }

            }
          


            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to add Faculty " };
            }
            return json;
        }
    }
}
