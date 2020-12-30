using EmployeeManagement.Models;
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

        [Inject]

        public IEmployeeService EmployeeService { get; set; }

        [Inject]

        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }
        [Parameter]

        public string Id { get; set; }

        protected async override Task OnInitializedAsync()

        {

            Employee = await EmployeeService.GetEmployee(int.Parse(Id));

            Departments = (await DepartmentService.GetDepartments()).ToList();

            DepartmentId = Employee.DepartmentId.ToString();


        }
    }

}
