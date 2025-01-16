using System.ComponentModel.DataAnnotations;

namespace InTechDA.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        [MaxLength(75)]
        public string Name { get; set; }

        // Foreign key to Department
        public int DepartmentID { get; set; }

        // Navigation property
        public Department? Department { get; set; }
    }
}
