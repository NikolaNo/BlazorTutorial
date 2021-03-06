﻿using EmployeeManagment.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagment.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        public HttpClient httpClient { get; }
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }      

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetJsonAsync<Employee[]>("api/employee");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetJsonAsync<Employee>($"api/employee/{id}");
        }

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            return await httpClient.PutJsonAsync<Employee>($"api/employee", updatedEmployee);
        }


        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            return await httpClient.PostJsonAsync<Employee>($"api/employee", newEmployee);
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employee/{id}");
        }
    }
}
