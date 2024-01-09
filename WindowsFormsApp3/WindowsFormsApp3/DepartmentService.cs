using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class DepartmentService
    {
        static HttpClient client = new HttpClient();

        public void createConnection()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8083/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> departments = null;
            HttpResponseMessage response = await client.GetAsync("api/department/getAll");
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response: " + resultString);

                try
                {
                    departments = JsonSerializer.Deserialize<List<Department>>(resultString);
                    return departments;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }
            return null;
        }

        public async Task<Department> CreateDepartmentAsync(Department newDepartment)
        {
            string jsonBody = JsonSerializer.Serialize(newDepartment);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/department/create", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating department: " + resultString);

                try
                {
                    Department createdDepartment = JsonSerializer.Deserialize<Department>(resultString);
                    return createdDepartment;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created department: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }

        public async Task<Department> UpdateDepartmentDescriptionAsync(String description, int id)
        {
            Department department = new Department(description, id);
            string jsonBody = JsonSerializer.Serialize(department);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/department/updateDescription/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating department: " + resultString);

                try
                {
                    Department createdDepartment = JsonSerializer.Deserialize<Department>(resultString);
                    return createdDepartment;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created department: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }

    }


}
