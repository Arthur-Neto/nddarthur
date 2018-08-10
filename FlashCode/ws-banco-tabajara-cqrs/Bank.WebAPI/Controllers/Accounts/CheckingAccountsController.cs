using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bank.Application.Features.Accounts;
using Bank.Application.Features.Accounts.Commands;
using Bank.Application.Features.Accounts.Queries;
using Bank.Application.Features.Accounts.ViewModels;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Transactions;
using Bank.WebAPI.Controllers.Common;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Bank.WebAPI.Controllers.Accounts
{
    [RoutePrefix("api/checkingaccounts")]
    public class CheckingAccountsController : ApiControllerBase
    {
        public ICheckingAccountService _accountsService;

        public CheckingAccountsController(ICheckingAccountService checkingAccountService)
        {
            _accountsService = checkingAccountService;
        }

        #region HttpGet
        [HttpGet]
        public IHttpActionResult Get()
        {
            var queryString = Request.GetQueryNameValuePairs()
                                    .Where(x => x.Key.Equals("quantity"))
                                    .FirstOrDefault();

            CheckingAccountQuery query = null;

            if (queryString.Key != null)
            {
                query = new CheckingAccountQuery();
                query.Quantity = int.Parse(queryString.Value);
            }

            var result = _accountsService.GetAll(query).ProjectTo<CheckingAccountViewModel>(); ;

            return HandleQueryable<CheckingAccountViewModel>(result);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var account = _accountsService.GetById(id);

            CheckingAccountViewModel accountViewModel = new CheckingAccountViewModel();

            accountViewModel = Mapper.Map<CheckingAccount, CheckingAccountViewModel>(account);

            return HandleCallback(() => accountViewModel);
        }

        [HttpGet]
        [Route("{id:int}/extract")]
        public IHttpActionResult GetExtracts(int id)
        {
            return HandleCallback(() => _accountsService.GetExtract(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(CheckingAccountRegisterCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Add(cmd));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(CheckingAccountUpdateCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Update(cmd));
        }

        [HttpPut]
        [Route("transfer")]
        public IHttpActionResult Transfer(CheckingAccountTransactionCommand cmd)
        {
            var validator = cmd.Validate(TransactionType.TRANSFER);

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Transfer(cmd));
        }

        [HttpPut]
        [Route("withdraw")]
        public IHttpActionResult Withdraw(CheckingAccountTransactionCommand cmd)
        {
            var validator = cmd.Validate(TransactionType.DEBT);

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Withdraw(cmd));
        }

        [HttpPut]
        [Route("deposit")]
        public IHttpActionResult Deposit(CheckingAccountTransactionCommand cmd)
        {
            var validator = cmd.Validate(TransactionType.CREDIT);

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Deposit(cmd));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(CheckingAccountRemoveCommand cmd)
        {
            var validator = cmd.Validate();

            if (!validator.IsValid)
                return HandleValidationFailure(validator.Errors);

            return HandleCallback(() => _accountsService.Remove(cmd));
        }

        #endregion HttpDelete

        #region HttpPatch
        [HttpPatch]
        [Route("{id:long}/status")]
        public IHttpActionResult UpdateStatus(long id)
        {
            return HandleCallback(() => _accountsService.UpdateStatus(id));
        }

        #endregion HttpPatch
    }
}
