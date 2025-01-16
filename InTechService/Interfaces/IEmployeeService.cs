using InTechCommon.DTO;

namespace InTechService.Interfaces
{
    public interface IEmployeeService 
    {
        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployee(int id);
        EmployeeDto AddEmployee(EmployeeDto employee);
        EmployeeDto UpdateEmployee(EmployeeDto employee);
        bool DeleteEmployee(int id);
    }
}
