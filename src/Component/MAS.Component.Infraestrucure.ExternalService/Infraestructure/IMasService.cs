using MAS.Component.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Component.ExternalService.Infraestructure
{
    public interface IMasService
    {
        Task<IList<Employee>> GetEmployees();
        
    }
}
