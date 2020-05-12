using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Infraestructure.DataBase
{
    public class EmployeeAux
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleDescription { get; set; }
        public decimal hourlySalary { get; set; }
        public decimal monthlySalary { get; set; }
        public decimal annualSalary { get; set; }
    }
}
