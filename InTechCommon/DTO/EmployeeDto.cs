namespace InTechCommon.DTO
{
    public class EmployeeDto : BaseDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }

        public string? DepartmentName { get; set; }
        public DepartmentDto? Department { get; set; }

    }
}
