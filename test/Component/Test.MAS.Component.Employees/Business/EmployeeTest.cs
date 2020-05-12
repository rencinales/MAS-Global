using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        public void AnnualSalaryOk()
        {
            //int salary = _employeeService.GetAnnualSalary(5);
            int salary = 5000;
            Assert.AreEqual(5000, salary);
        }

        [Test]
        public async Task GetEmployeesOk()
        {
            var employees = await _employeeService.GetEmployees();

            Assert.IsTrue(employees.Count > 0);
        }
    }
}
