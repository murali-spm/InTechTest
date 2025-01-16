using InTechCommon.DTO;
using InTechCommon.Exceptions;
using InTechDA.Repository;
using InTechService.Interfaces;

namespace InTechService
{
    public class EmployeeService(IEmployeeRepo employeeRepo) : BaseService, IEmployeeService
    {   
        public List<EmployeeDto> GetAllEmployees()
        {           
            // throw new InTechException("test error");
            return employeeRepo.GetAllEmployees();
        }

        public EmployeeDto AddEmployee(EmployeeDto employee)
        {
            return employeeRepo.AddEmployee(employee);
        }

        public EmployeeDto UpdateEmployee(EmployeeDto employee) { 
            return employeeRepo.UpdateEmployee(employee);
        }

        public bool DeleteEmployee(int id) {
            return employeeRepo.DeleteEmployee(id);
        }

        public EmployeeDto GetEmployee(int id) { 
            return employeeRepo.GetEmployee(id);
        }
    }
}
