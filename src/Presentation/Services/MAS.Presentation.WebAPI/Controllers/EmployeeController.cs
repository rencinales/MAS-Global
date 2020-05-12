using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS.Aplication.DTOs;
using MAS.Aplication.UsesCases;
using Microsoft.AspNetCore.Mvc;
using MAS.Component.Employees.Infraestructure;

namespace MAS.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IGetEmployee _getEmployee;
        private readonly IRepository _repository;


        public EmployeeController(IGetEmployee getEmployee, IRepository repository)
        {
            _repository = repository;
            _getEmployee = getEmployee;
        }
        
        [HttpGet("GetEmployees")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task< IList<EmployeeDTO>> GetEmployees()
        {
            return await _getEmployee.GetEmployees();
        }

        [HttpGet("GetEmployees/{id}")]
        [ResponseCache(Duration = 120, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<EmployeeDTO> GetEmployees(int id)
        {
            return await _getEmployee.GetEmployees(id);
        }
    }
}