using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasGobalDevTest.BL.DTO;
using MasGobalDevTest.BL.Factory;
using MasGobalDevTest.DA;
using MasGobalDevTest.DA.Models;

namespace MasGobalDevTest.BL
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            try
            {
                var employees = await _employeeRepository.GetAllAsync();
                var employeesDTO = new List<EmployeeDTO>();
                foreach(var employee in employees)
                {
                    var creator = new ConcreteCreator();
                    var employeeDTO = creator.GetEmployee(employee);
                    employeesDTO.Add(employeeDTO);
                }
                return employeesDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            try
            {
                var employee = await _employeeRepository.GetByIdAsync(id);
                var creator = new ConcreteCreator();
                var employeeDTO = creator.GetEmployee(employee);
                return employeeDTO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
