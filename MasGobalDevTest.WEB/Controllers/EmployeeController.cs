using MasGobalDevTest.WEB.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MasGobalDevTest.WEB.Controllers
{
    public class EmployeeController : Controller
    {
        private const string BaseUrl = "http://localhost:51036/api/";

        // GET: Employees
        public ActionResult Index(string searchString)
        {
            return View();
        }

        
        [HttpGet()]
        public async Task<ActionResult> GetEmployees(int id = 0)
        {
            var employeesList = new List<EmployeeViewModel>();
            if (id > 0)
            {
                var employee = await GetEmployeeById(id);
                if (employee != null)
                {
                    employeesList.Add(employee);
                }
            }
            else
            {
                var employees = await GetAllEmployees();
                if(employees != null)
                {
                    employeesList.AddRange(employees);
                }
            }
            return PartialView("_Employees",employeesList);
        }

        private async Task<IEnumerable<EmployeeViewModel>> GetAllEmployees()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("Employees");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var stringResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(stringResponse);
                return data;
            }
        }

        private async Task<EmployeeViewModel> GetEmployeeById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync($"Employees/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                var stringResponse = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<EmployeeViewModel>(stringResponse);
                return data;
            }
        }
    }
    
}