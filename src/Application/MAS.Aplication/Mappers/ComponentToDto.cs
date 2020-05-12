using MAS.Component.Core.Entities;
using MAS.Aplication.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAS.Aplication.Mappers
{
    static public class MapperToDto
    {
        static public EmployeeDTO ComponentToDto(Employee component)
        {
            var model = new EmployeeDTO()
            {
                Id = component.Id,
                Name = component.Name,
                contractTypeName = component.contractTypeName,
                AnualSalary = component.annualSalary
            };
            return model;

        }

        static public IList<EmployeeDTO> ComponentToDto(IList<Employee> componentList)
        {
            var list = new List<EmployeeDTO>();
            int until = componentList.Count;
            for (int i = 0; i < until; i++)
            {
                
                list.Add(MapperToDto.ComponentToDto(componentList[i]));
            }
            return list;
        }
    }
}
