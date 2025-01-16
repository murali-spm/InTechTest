using AutoMapper;
using InTechCommon.DTO;
using InTechDA.Entities;

namespace InTechService
{
    public class DTOModelMapping
    {
        public static MapperConfiguration RegisterMaps() {

            MapperConfiguration mappingConfig = new MapperConfiguration(
                config => {
                    config.CreateMap<EmployeeDto, Employee>();
                    config.CreateMap<Employee, EmployeeDto>();

                    config.CreateMap<Department, DepartmentDto>();
                });

            return mappingConfig;
        }
    }
}
