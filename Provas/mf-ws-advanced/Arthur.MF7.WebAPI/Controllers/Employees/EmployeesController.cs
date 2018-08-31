using Arthur.MF7.Application.Features.Employees;
using Arthur.MF7.Application.Features.Employees.Commands;
using Arthur.MF7.Application.Features.Employees.ViewModels;
using Arthur.MF7.Domain.Features.Employees;
using Arthur.MF7.WebAPI.Controllers.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Web.Http;

namespace Arthur.MF7.WebAPI.Controllers.Employees
{
    [RoutePrefix("api/employees")]
    public class EmployeesController : ApiControllerBase
    {
        public IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #region HttpGet
        [HttpGet]
        public IHttpActionResult Get()
        {
            IQueryable<EmployeeViewModel> result = _employeeService.GetAll().ProjectTo<EmployeeViewModel>();

            return HandleQueryable<EmployeeViewModel>(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            Employee employee = _employeeService.GetById(id);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();

            employeeViewModel = Mapper.Map<Employee, EmployeeViewModel>(employee);

            return HandleCallback(() => employeeViewModel);
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(EmployeeRegisterCommand cmd)
        {
            FluentValidation.Results.ValidationResult validator = cmd.Validate();

            if (!validator.IsValid)
            {
                return HandleValidationFailure(validator.Errors);
            }

            return HandleCallback(() => _employeeService.Add(cmd));
        }

        #endregion HttpPost

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(EmployeeRemoveCommand cmd)
        {
            FluentValidation.Results.ValidationResult validator = cmd.Validate();

            if (!validator.IsValid)
            {
                return HandleValidationFailure(validator.Errors);
            }

            return HandleCallback(() => _employeeService.Remove(cmd));
        }

        #endregion HttpDelete

        #region HttPut
        [HttpPut]
        public IHttpActionResult Put(EmployeeUpdateCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _employeeService.Update(cmd));
        }

        #endregion
    }
}