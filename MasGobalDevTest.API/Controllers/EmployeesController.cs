using MasGobalDevTest.BL;
using MasGobalDevTest.BL.DTO;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasGobalDevTest.API.Controllers
{
    /// <summary>
    /// Return Employees Data
    /// </summary>
    [RoutePrefix("employees")]
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Gets a list of employees with their data
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Returns the list of employees", typeof(IEnumerable<EmployeeDTO>))]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        /// <summary>
        /// Get specific employee information
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a specific employee</returns>
        [SwaggerResponse(HttpStatusCode.OK, "Returns a specific employee", typeof(EmployeeDTO))]
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }
    }
}
