using MAS.Component.Employees.Infraestructure;
using MAS.Aplication.DTOs;
using MAS.Aplication.UsesCases;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Test.MAS.Presentation.Aplication
{
    public class GetEmployeeTest
    {
        private readonly IGetEmployee _getEmployees;
        private readonly IRepository _repository;

        public GetEmployeeTest()
        {
            _repository = new Repository();
            _getEmployees = new GetEmployee(_repository);
        }

        //[SetUp]
        //public void Setup()
        //{

        //}

        [Test]
        public async Task  GetEmployee_Ok()
        {
            var employeeList = await _getEmployees.GetEmployees();
            Assert.IsTrue(employeeList.Count > 0);
        }

        [Test]
        [TestCase (1)]
        public async Task GetEmployeeById_Ok(int id)
        {
            var employee = await _getEmployees.GetEmployees(id);
            Assert.IsTrue(employee.Id == id);
        }

    }
}