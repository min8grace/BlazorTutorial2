using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {

        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]

        public IEmployeeService EmployeeService { get; set; }

        [Inject]

        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }
        [Parameter]

        public string Id { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();

            Mapper.Map(Employee, EditEmployeeModel);

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Department = Employee.Department;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;
        }
        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EditEmployeeModel, Employee);
            var result = await EmployeeService.UpdateEmployee(Employee);
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }

}
