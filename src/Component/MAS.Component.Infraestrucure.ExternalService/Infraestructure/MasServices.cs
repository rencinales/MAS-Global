using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MAS.Component.Core.Entities;

namespace MAS.Component.ExternalService.Infraestructure
{
    public class MasService: IMasService
    {
        private const string BaseUrl = "http://masglobaltestapi.azurewebsites.net/api/Employees";
        private readonly HttpClient _client;

        public MasService()
        {
            _client = new HttpClient();
        }
       
      

        async Task<IList<Employee>> IMasService.GetEmployees()
        {
            var httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve tasks");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(content);
            return employees;
        }
    }
}
