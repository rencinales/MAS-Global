using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MAS.Component.Employees.Infraestructure;

namespace Test.MAS.Component.Employees.Infraestructure
{
    class RepositoryTest
    {
        private readonly IRepository repository;

        public RepositoryTest()
        {
            repository = new Repository();
        }

        [Test]
        public void AnnualSalaryOk()
        {
            int salary = repository.AnnualSalary();
            
            Assert.AreEqual(5000, salary);
        }
        public void AnnualSalaryNoOk()
        {
            int salary = repository.AnnualSalary();

            Assert.AreNotEqual(5000, salary);
        }
    }
}
