using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MAS.Aplication.DTOs;
using MAS.Aplication.UsesCases;
using MAS.Presentation.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MAS.Presentation.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGetEmployee _getEmployee;
        private readonly HttpClient _httpClient;
        public EmployeeController(IGetEmployee getEmployee, HttpClient httpClient)
        {
            _getEmployee = getEmployee;
            _httpClient = httpClient;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = new List<EmployeeDTO>();
            return View(employees);
        }
        public async Task<IList<EmployeeDTO>> GetEmployees()
        {
            return await _getEmployee.GetEmployees();

        }
        public async Task<EmployeeDTO> GetEmployees(int id)
        {
            return await _getEmployee.GetEmployees(id);
        }

        [HttpPost]
        public async Task<IActionResult> GetEmployeesLibrary(string id)
        {
            IList<EmployeeDTO> employees;
            if (id != "" && id != null)
            {
                employees = new List<EmployeeDTO>();
                var employee = await _getEmployee.GetEmployees(Convert.ToInt32(id));
                employees.Add(employee);
            }
            else
                employees = await _getEmployee.GetEmployees();

            return View("Index", employees);
        }
        [HttpGet]
        public async Task<IActionResult> Api()
        {
            var employees = new List<EmployeeDTO>();
            return View(employees);
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployeesAPI(string id, string url)
        {
            var content = await GetEmployeeAPI(id, url);
            IList<EmployeeDTO> employees;
            if (id != "" && id != null)
            {
                employees = new List<EmployeeDTO>();
                var employee = JsonConvert.DeserializeObject<EmployeeDTO>(content);
                employees.Add(employee);
            }
            else
                employees = JsonConvert.DeserializeObject<List<EmployeeDTO>>(content);

            return View("API", employees);
        }

        public async Task<string> GetEmployeeAPI(string id, string url)
        {   
            var content = "";
            if (id != "" && id != null)
            {
                url += "/" + id;                
                var httpResponse = await _httpClient.GetAsync(url);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }
                content = await httpResponse.Content.ReadAsStringAsync();
            }
            else
            {
             
                var httpResponse = await _httpClient.GetAsync(url);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot retrieve tasks");
                }
                content = await httpResponse.Content.ReadAsStringAsync();
            }
            return content;

        }
    }
}