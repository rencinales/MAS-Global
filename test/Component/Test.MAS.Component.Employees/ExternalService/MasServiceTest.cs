using MAS.Component.ExternalService.Infraestructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Test.MAS.Component.Employees.ExternalService
{
    class MasServiceTest
    {
        private readonly IMasService _masService;
        public MasServiceTest()
        {
            _masService = new MasService();
        }

        [Test]
        public async Task GetEmployees_Ok()
        {
            var employees = await _masService.GetEmployees();

            Assert.IsTrue(employees.Count > 0);
        }

        [Test]
        public async Task GetEmployees_NoOk()
        {
            var employees = await _masService.GetEmployees();            
            Assert.IsTrue((employees== null)||(employees.Count==0));
        }
    }
}
