using System.ComponentModel.DataAnnotations;

namespace InTechBlazoreClient.Components.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(75, ErrorMessage = "Employee Name can't be longer than 75 characters.")]
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Department is required")]
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
    }
}
