using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {

        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "FirstName is mandatory")]
        [MinLength(2)]

        public string FirstName { get; set; }

        [Required]

        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(AllowedDomain = "pragimtech.com")]

        public string Email { get; set; }

        [CompareProperty("Email", ErrorMessage = "Email and Confirm Email must match")]

        public string ConfirmEmail { get; set; }

        public DateTime DateOfBrith { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        [ValidateComplexType]
        public Department Department { get; set; } = new Department();

        public string PhotoPath { get; set; }

    }
}
