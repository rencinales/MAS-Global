using MAS.Component.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.Employees.Infraestructure
{
    public interface IRepository
    {
        int AnnualSalary();

        Task<IList<Employee>> GetEmployees();
    }
}
