using MAS.Component.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.Employees.Infraestructure
{
    public class Repository2 : IRepository
    {
        public int AnnualSalary()
        {
            return 1;
        }
        public Task <IList<Employee>> GetEmployees()
        {
            IList<Employee> employees = new List<Employee>();
            return Task.FromResult(employees);
        }
    }
}
