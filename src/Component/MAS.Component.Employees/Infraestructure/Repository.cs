using MAS.Component.Core.Entities;
using MAS.Component.ExternalService.Infraestructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.Employees.Infraestructure
{
    public class Repository : IRepository
    {
        private readonly IMasService _masService;

        public Repository()
        {
            _masService = new MasService();
        }
        public int AnnualSalary()
        {
            return 7000;
        }
        public Task <IList<Employee>> GetEmployees()
        {   
            return _masService.GetEmployees();
        }
    }
}
