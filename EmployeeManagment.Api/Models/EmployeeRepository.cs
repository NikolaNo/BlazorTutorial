using EmployeeManagement.Api.Models;
using EmployeeManagment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result =await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = appDbContext.Employees
                .Where(x => x.EmployeeId == employeeId)
                .FirstOrDefault();

            if (result != null)
            {
                appDbContext.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees.Include(x=>x.Department)
                .Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.FirstName.Contains(name) 
                || x.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(x => x.Gender == gender);
            }

            return await query.ToListAsync();

        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = appDbContext.Employees
                .Where(x => x.EmployeeId == employee.EmployeeId)
                .FirstOrDefault();

            if (result != null)
            {
                result.DateOfBrith = employee.DateOfBrith;
                result.Departmentid = employee.Departmentid;
                result.Email = employee.Email;
                result.FirstName = employee.FirstName;
                result.Gender = employee.Gender;
                result.LastName = employee.LastName;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
                return result;
            
            }
            return null;
        }
    }
}
