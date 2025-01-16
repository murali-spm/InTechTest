using System.ComponentModel.DataAnnotations;

namespace InTechDA.Entities
{
    public class Department
    {
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
