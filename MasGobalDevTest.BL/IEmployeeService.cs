using MasGobalDevTest.BL.DTO;
using MasGobalDevTest.DA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGobalDevTest.BL
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeDTO>> GetAllAsync();
    }
}
