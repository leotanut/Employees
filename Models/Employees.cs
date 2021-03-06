using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Employees.Models;
namespace Employees.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public Nullable<System.DateTime> Date_of_Birth { get; set; }
        public Nullable<System.DateTime> Start_Work_Date { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public Nullable<decimal> Pvd_fund_rate { get; set; }
        public Nullable<decimal> Total_fund { get; set; }
    }
  /*  public partial class EmployeesEntities2 : DbContext
    {
        public DbSet<Employer> Emp { get; set; }
    }*/


}
 