using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employees.Models;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {
        private EmployeesEntities2 db = new EmployeesEntities2();
        public ActionResult Index()
        {
            List<Employer> empList = new List<Employer>();
            Employer employee = new Employer();
            //Work 2 months
            empList.Add(new Employer { Id = 1, First_name = "Tanut", Last_name = "Namcot", Date_of_Birth = new DateTime(1998, 8, 3),Start_Work_Date= new DateTime(2021, 1, 1),Salary=20000,Pvd_fund_rate=0,Total_fund=0});
            //Work 7 months
            empList.Add(new Employer { Id = 2, First_name = "Employee", Last_name = "B", Date_of_Birth = new DateTime(1998, 8, 3), Start_Work_Date = new DateTime(2020, 8, 1), Salary = 20000, Pvd_fund_rate = 3, Total_fund=0 });
            //Work 13 months
            empList.Add(new Employer { Id = 3, First_name = "Employee", Last_name = "C", Date_of_Birth = new DateTime(1998, 8, 3), Start_Work_Date = new DateTime(2020, 2, 1), Salary = 20000, Pvd_fund_rate = 5, Total_fund = 0 });
            DateTime now = DateTime.Now;
            
            foreach (var emp in empList)
            {
                var dif = GetMonthDifference(now, emp.Start_Work_Date.GetValueOrDefault());
                emp.Id = dif;
              if (dif < 3 || dif < 0)
                {
                    dif = 0;
                    emp.Total_fund = 0;
                }
               if(dif>=3)
                {
                 var paymonth = dif - 3;
                 if (dif>=12) { paymonth = 9; }
                    emp.Total_fund = emp.Total_fund + (((emp.Salary * 10) / 100) * paymonth) + ((emp.Salary * emp.Pvd_fund_rate) / 100) * paymonth;
                }
               if (dif >= 12)
                {
                    var paymonth = dif - 12;
                    if (dif >= 36) { paymonth = 24; }
                    emp.Total_fund = emp.Total_fund + (((emp.Salary * 30) / 100) * paymonth) + ((emp.Salary * emp.Pvd_fund_rate) / 100) * paymonth;
               
                }
                if (dif >= 36)
                {
                    var paymonth = dif - 36;
                    if (dif >= 60) { paymonth = 24; }
                    emp.Total_fund = emp.Total_fund + (((emp.Salary * 50) / 100) * paymonth) + ((emp.Salary * emp.Pvd_fund_rate) / 100) * paymonth;
                }
                if (dif > 60)
                {
                    var paymonth = dif - 60;
                    emp.Total_fund = emp.Total_fund + (((emp.Salary * 80) / 100) * paymonth) + ((emp.Salary * emp.Pvd_fund_rate) / 100) * paymonth;
                }

            }
            return View(empList);
        }
        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = ((startDate.Year - endDate.Year) * 12) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}