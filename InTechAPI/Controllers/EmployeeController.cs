using Microsoft.AspNetCore.Mvc;
using InTechCommon.DTO;
using InTechService.Interfaces;
using System.Net;
using InTechCommon.Constants;
using InTechCommon.Exceptions;

namespace InTechAPI.Controllers
{
    [Route("api/v{version.apiVersion}/employee")]
    public class EmployeeController(IEmployeeService employeeService) : BaseController
    {
        [HttpGet]
        [Route("")]
        public ResponseDto GetEmployees()
        {         
            return ReturnResponse(employeeService.GetAllEmployees());
        }

        [HttpGet]
        [Route("{Id}")]
        public ResponseDto GetEmployees(int Id)
        {
            return ReturnResponse(employeeService.GetEmployee(Id));
        }

        [HttpPost]
        public ResponseDto AddEmployee(EmployeeDto employeeDto)
        {
            if(employeeDto == null)
            {
                return new ResponseDto(HttpStatusCodes.BAD_REQUEST, Messages.FAIL, null, "Employee data rquired.");
            }
            //Example of global error handling
            if (string.IsNullOrEmpty(employeeDto.Name)) {
                throw new InTechException("Name is required", true);//The hardcoded strings can be moved to constants or we can add any validation lib to handle this.
            }

            employeeService.AddEmployee(employeeDto);
            return ReturnResponse(employeeDto);
        }

        [HttpPatch]
        public ResponseDto UpdateEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                return new ResponseDto(HttpStatusCodes.BAD_REQUEST, Messages.FAIL, null, "Employee data rquired.");
            }
            //Example of global error handling
            if (string.IsNullOrEmpty(employeeDto.Name))
            {
                throw new InTechException("Name is required", true);//The hardcoded strings can be moved to constants or we can add any validation lib to handle this.
            }

            employeeService.UpdateEmployee(employeeDto);
            return ReturnResponse(employeeDto);
        }

        [HttpDelete]
        [Route("{Id}")]
        public ResponseDto DeleteEmployee(int Id) {
           return ReturnResponse( employeeService.DeleteEmployee(Id));
        }
    }
}
