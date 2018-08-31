using Arthur.MF7.Application.Features.Spendings;
using Arthur.MF7.Application.Features.Spendings.Commands;
using Arthur.MF7.Application.Features.Spendings.ViewModels;
using Arthur.MF7.Domain.Features.Spendings;
using Arthur.MF7.WebAPI.Controllers.Common;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Web.Http;

namespace Arthur.MF7.WebAPI.Controllers.Spendings
{
    [RoutePrefix("api/spendings")]
    public class SpendingsController : ApiControllerBase
    {
        public ISpendingService _spendingService;

        public SpendingsController(ISpendingService spendingService)
        {
            _spendingService = spendingService;
        }

        #region HttpGet
        [HttpGet]
        [Authorize]
        public IHttpActionResult Get()
        {
            IQueryable<SpendingViewModel> result = _spendingService.GetAll().ProjectTo<SpendingViewModel>();

            return HandleQueryable<SpendingViewModel>(result);
        }

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            Spending spending = _spendingService.GetById(id);

            SpendingViewModel spendingViewModel = new SpendingViewModel();

            spendingViewModel = Mapper.Map<Spending, SpendingViewModel>(spending);

            return HandleCallback(() => spendingViewModel);
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post(SpendingRegisterCommand cmd)
        {
            FluentValidation.Results.ValidationResult validator = cmd.Validate();

            if (!validator.IsValid)
            {
                return HandleValidationFailure(validator.Errors);
            }

            return HandleCallback(() => _spendingService.Add(cmd));
        }

        #endregion HttpPost

        #region HttpDelete
        [HttpDelete]
        [Authorize]
        public IHttpActionResult Delete(SpendingRemoveCommand cmd)
        {
            FluentValidation.Results.ValidationResult validator = cmd.Validate();

            if (!validator.IsValid)
            {
                return HandleValidationFailure(validator.Errors);
            }

            return HandleCallback(() => _spendingService.Remove(cmd));
        }

        #endregion HttpDelete
    }
}
