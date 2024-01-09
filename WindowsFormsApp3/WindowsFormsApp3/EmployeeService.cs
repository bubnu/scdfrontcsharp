using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WindowsFormsApp3;

namespace WinFormsApp3
{
    internal class EmployeeService
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

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = null;
            HttpResponseMessage response = await client.GetAsync("api/employee/getAll");
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("gata : " + resultString);
                employees = JsonSerializer.Deserialize<List<Employee>>(resultString);
                return employees;
                
            }
            return null;
        }

        public async Task<Employee> CreateEmployeeAsync(Employee newEmployee)
        {
            string jsonBody = JsonSerializer.Serialize(newEmployee);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/employee/create", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating employee: " + resultString);

                try
                {
                    Employee createdEmployee = JsonSerializer.Deserialize<Employee>(resultString);
                    return createdEmployee;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created employee: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }

        public async Task<Employee> UpdateEmployeeNameAsync(string name, int id)
        {
            Employee newEmployee = new Employee(id,name);

            string jsonBody = JsonSerializer.Serialize(newEmployee);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/employee/updateName/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating employee: " + resultString);

                try
                {
                    Employee createdEmployee = JsonSerializer.Deserialize<Employee>(resultString);
                    return createdEmployee;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created employee: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }

        public async Task<Employee> UpdateEmployeeEmailAsync(string email, int id)
        {
            Employee newEmployee = new Employee(email, id);

            string jsonBody = JsonSerializer.Serialize(newEmployee);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/employee/updateEmail/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating employee: " + resultString);

                try
                {
                    Employee createdEmployee = JsonSerializer.Deserialize<Employee>(resultString);
                    return createdEmployee;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created employee: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }

        public async Task<Employee> UpdateEmployeeDepartmentIDAsync(int departmentID, int id)
        {
            Employee newEmployee = new Employee(departmentID, id);

            string jsonBody = JsonSerializer.Serialize(newEmployee);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/employee/updateEmployeeDepartment/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received JSON response after creating employee: " + resultString);

                try
                {
                    Employee createdEmployee = JsonSerializer.Deserialize<Employee>(resultString);
                    return createdEmployee;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error during deserialization of created employee: " + ex.Message);
                    throw; // Rethrow the exception to indicate the issue
                }
            }

            return null;
        }
    }
 }
