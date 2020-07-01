using AutoMapper;
using EmployeeManagment.Models;
using EmployeeManagment.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        public IMapper Mapper { get; set; }

        protected async override Task OnInitializedAsync()
        {
            
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();

            //Mapper.Map(Employee, EditEmployeeModel);

            EditEmployeeModel.Email = Employee.Email;
            EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            EditEmployeeModel.Department = Employee.Department;
            EditEmployeeModel.Departmentid = Employee.Departmentid;
            EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            EditEmployeeModel.FirstName = Employee.FirstName;
            EditEmployeeModel.Gender = Employee.Gender;
            EditEmployeeModel.LastName = Employee.LastName;
            EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            EditEmployeeModel.ConfirmEmail = Employee.Email;

        }
        protected async Task HandleValidSubmit()
        {

            //Mapper.Map(EditEmployeeModel, Employee);
            Employee.Email = EditEmployeeModel.Email;
            Employee.DateOfBrith = EditEmployeeModel.DateOfBrith;
            Employee.Department = EditEmployeeModel.Department;            
            Employee.EmployeeId = EditEmployeeModel.EmployeeId;
            Employee.FirstName = EditEmployeeModel.FirstName;
            Employee.Gender = EditEmployeeModel.Gender;
            Employee.LastName = EditEmployeeModel.LastName;
            Employee.PhotoPath = EditEmployeeModel.PhotoPath;
            
            var result = await EmployeeService.UpdateEmployee(Employee);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }

        }

    }
}
