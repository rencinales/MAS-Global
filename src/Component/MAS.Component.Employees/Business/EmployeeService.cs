using MAS.Component.Core.Entities;
using MAS.Component.Employees.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.Employees.Business
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository _repository;
        public EmployeeService(IRepository repository)
        {
            _repository = repository;
            
        }

        public decimal GetAnnualSalary(ContractType contractType, decimal monthly, decimal hourly )
        {
            decimal AnnualSalary=0;
            switch (contractType)
            {
                case ContractType.HourlySalaryEmployee:
                    AnnualSalary = 120 * hourly * 12;
                    break;
                case ContractType.MonthlySalaryEmployee:
                    AnnualSalary = monthly * 12;
                    break;

            }
            return AnnualSalary;
        }

        public Task<IList<Employee>> GetEmployees()
        {
            var employees = _repository.GetEmployees();
            ContractType contractType;
            foreach (Employee employee in employees.Result)
            {
                contractType = employee.contractTypeName == "HourlySalaryEmployee" ? ContractType.HourlySalaryEmployee : ContractType.MonthlySalaryEmployee;
                employee.annualSalary = GetAnnualSalary(contractType, employee.monthlySalary, employee.hourlySalary);
            }
            return employees;
        }
    }
}
