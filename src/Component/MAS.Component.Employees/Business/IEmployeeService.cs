using MAS.Component.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.Employees.Business
{
    public interface IEmployeeService
    {   

        decimal GetAnnualSalary(ContractType contractType, decimal monthly, decimal hourly);

        Task <IList<Employee>> GetEmployees();
    }
}
