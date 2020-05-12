using MAS.Component.Core.Entities;
using MAS.Component.Employees.Business;
using MAS.Component.Employees.Infraestructure;
using MAS.Aplication.DTOs;
using MAS.Aplication.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Aplication.UsesCases
{
    public class GetEmployee : IGetEmployee
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRepository _repository;

        public GetEmployee(IRepository repository)
        {
            _employeeService = new EmployeeService(repository);
        }

        public async Task< IList<EmployeeDTO>> GetEmployees()
        {
            var employees= await _employeeService.GetEmployees();
            return MapperToDto.ComponentToDto(employees);
        }

        public async Task<EmployeeDTO> GetEmployees(int id)
        {
            var employees = await _employeeService.GetEmployees();
            var employee=employees.First(employee => employee.Id == id);

            return MapperToDto.ComponentToDto(employee);
        }
    }
}
