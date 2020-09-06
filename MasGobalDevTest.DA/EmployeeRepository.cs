using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MasGobalDevTest.DA.Models;
using Newtonsoft.Json;

namespace MasGobalDevTest.DA
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string BaseUrl = "http://masglobaltestapi.azurewebsites.net/api/";

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                var employees = await GetData();
                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            try
            {
                var employees = await GetData();
                var employee = employees.Where(x => x.Id == id).FirstOrDefault();
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async Task<IEnumerable<Employee>> GetData()
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
                var data = JsonConvert.DeserializeObject<IEnumerable<Employee>>(stringResponse);
                return data;
            }
        }
    }
}
