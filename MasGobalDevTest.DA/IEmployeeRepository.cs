using MasGobalDevTest.DA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGobalDevTest.DA
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
    }
}
