using AutoMapper;
using InTechDA.Entities;
using InTechCommon.DTO;

namespace InTechDA.Repository
{
    public interface IDepartmentRepo : IRepository<Department>
    {

        List<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartment(int id);

    }


    public class DepartmentRepo : Repository<Department>, IDepartmentRepo
    {
        private IMapper _mapper;
        public DepartmentRepo(IMapper mapper, InTechDBContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<DepartmentDto> GetAllDepartments()
        {
            List<Department> Departments = GetAll();
            //List<DepartmentDto> DepartmentDtos = Departments.ConvertProperties<Department, DepartmentDto>();
            List<DepartmentDto> DepartmentDtos = _mapper.Map<List<DepartmentDto>>(Departments);
            return DepartmentDtos;
        }

        public DepartmentDto GetDepartment(int id)
        {
            //DepartmentDto Department = Context.Departments.FromSqlInterpolated($"GetDepartmentByID {id}").FirstOrDefault().ConvertProperties<Department, DepartmentDto>();
            return new DepartmentDto();
        }
    }
}
