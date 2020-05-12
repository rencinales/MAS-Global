using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MAS.Component.Core.Entities;
using MAS.Component.Employees.Business;
using MAS.Component.Employees.Infraestructure;
using NUnit.Framework;

namespace Test.MAS.Component.Employees.Business
{
    
    class EmployeeTest
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRepository _repository;

        public EmployeeTest()
        {
            _repository = new Repository();
            _employeeService = new EmployeeService(_repository);
        }
        [Test]
        public void AnnualSalaryHourlyOk()
        {       
            decimal salary = _employeeService.GetAnnualSalary(ContractType.HourlySalaryEmployee, Convert.ToDecimal(100), Convert.ToDecimal(100));            
            Assert.AreEqual(144000, salary);
        }
        [Test]
        public void AnnualSalaryMonthlyOk()
        {
            decimal salary = _employeeService.GetAnnualSalary(ContractType.MonthlySalaryEmployee, Convert.ToDecimal(100), Convert.ToDecimal(100));
            Assert.AreEqual(1200, salary);
        }

        [Test]
        public async Task GetEmployeesOk()
        {
            var employees = await _employeeService.GetEmployees();

            Assert.IsTrue(employees.Count > 0);
        }
    }
}
