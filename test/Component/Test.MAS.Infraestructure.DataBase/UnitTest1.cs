using NUnit.Framework;
using MAS.Infraestructure.DataBase;

namespace Test.MAS.Infraestructure.DataBase
{
    public class Tests
    {
        
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void Test1()
        {
            //SqlLiteDataAccess sqllitedataacces = new SqlLiteDataAccess();
            var employees=SqlLiteDataAccess.GetEmployees();
            Assert.IsTrue(employees.Count > 0);
        }
    }
}