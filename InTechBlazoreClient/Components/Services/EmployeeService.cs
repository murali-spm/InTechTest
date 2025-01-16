using InTechBlazoreClient.Components.Models;
using Newtonsoft.Json;

namespace InTechBlazoreClient.Components.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private string _apiUrl = "https://localhost:7100/api/v1.0/";
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeModel>> GetEmployeesAsync()
        {
            var response =  await _httpClient.GetFromJsonAsync<ResponseDto>("employee");
            List<EmployeeModel> result = new List<EmployeeModel>();
            if (response != null && response.Data != null)
            {
                result = JsonConvert.DeserializeObject<List<EmployeeModel>>(response.Data.ToString());
            }
            return result;
        }

        public async Task<EmployeeModel> GetEmployeeAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ResponseDto>("employee/"+id);
            EmployeeModel result = new EmployeeModel();
            if (response != null && response.Data != null)
            {
                result = JsonConvert.DeserializeObject<EmployeeModel>(response.Data.ToString());
            }
            return result;
        }

        public async Task CreateEmployeeAsync(EmployeeModel employee)
        {
            var response = await _httpClient.PostAsJsonAsync("employee", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            var response = await _httpClient.PatchAsJsonAsync($"employee", employee);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"employee/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
