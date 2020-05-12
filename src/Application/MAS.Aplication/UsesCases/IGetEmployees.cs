using MAS.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MAS.Aplication.UsesCases
{
    public interface IGetEmployee
    {
        Task<IList<EmployeeDTO>> GetEmployees();
        Task <EmployeeDTO> GetEmployees(int id);
    }
}
