using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAS.Aplication.DTOs;
using MAS.Aplication.UsesCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MAS.Presentation.Web.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly IGetEmployee _getEmployee;
        public EmployeeModel(IGetEmployee getEmployee)
        {
            _getEmployee = getEmployee;
        }
        public async Task OnGet()
        {
            EmployeeDTO = new EmployeeDTO();
            EmployeeDTOLst =  await _getEmployee.GetEmployees();
        }

        [BindProperty]
        public EmployeeDTO EmployeeDTO { get; set; }

        [BindProperty]
        public IEnumerable<EmployeeDTO> EmployeeDTOLst { get; set; }

        public async Task <IActionResult> GetEmployees()
        {
            //return await _getEmployee.GetEmployees();
            EmployeeDTO= await _getEmployee.GetEmployees(1);
            //Customer = await _context.Customers.FindAsync(id);

            if (EmployeeDTO == null)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
        
    }
}