using AutoMapper;
using InTechDA.Entities;
using Microsoft.EntityFrameworkCore;
using InTechCommon.DTO;
using InTechCommon.Helpers;
using InTechCommon.Exceptions;

namespace InTechDA.Repository
{

    public interface IEmployeeRepo : IRepository<Employee> {

        List<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployee(int id);

        EmployeeDto AddEmployee(EmployeeDto dto);
        EmployeeDto UpdateEmployee(EmployeeDto dto);

        bool DeleteEmployee(int id);

    }

    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        private IMapper _mapper;
        public EmployeeRepo(IMapper mapper, InTechDBContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            var result = from e in Context.Employees
                                       join d in Context.Departments on e.DepartmentID equals d.ID
                                       select new EmployeeDto()
                                       {
                                         ID = e.ID,
                                         Name = e.Name,
                                         DepartmentID = e.DepartmentID,
                                         DepartmentName = d.Name
                                       };
            List<EmployeeDto> EmployeeDtos  = _mapper.Map<List<EmployeeDto>>(result.ToList());

            return EmployeeDtos;
        }

        public EmployeeDto GetEmployee(int id)
        {
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(GetById(id));
            return employeeDto;
        }

        public EmployeeDto AddEmployee(EmployeeDto dto)
        {
            Employee employee = _mapper.Map<Employee>(dto);
            int id = Insert(employee);
            dto.ID = employee.ID;
            return dto;
        }

        public EmployeeDto UpdateEmployee(EmployeeDto dto)
        {
            Employee? employee = GetById(dto.ID);
            if (employee == null) {
                throw new InTechException("Employee not found", true);
            }
            employee =_mapper.Map(dto, employee);
            int id = Update(employee);
            return dto;
        }

        public bool DeleteEmployee(int id)
        {
            Employee? employee = GetById(id);
            if (employee == null)
            {
                throw new InTechException("Employee not found", true);
            }
            Delete(employee);
            return true;
        }
    }
}
