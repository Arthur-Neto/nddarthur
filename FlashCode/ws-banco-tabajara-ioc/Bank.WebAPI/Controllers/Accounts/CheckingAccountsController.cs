using Bank.Application.Features.Accounts;
using Bank.Domain.Features.Accounts;
using Bank.Domain.Features.Clients;
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
            int? quantity = null;
            if (queryString.Key != null)
                quantity = int.Parse(queryString.Value);

            var query = _accountsService.GetAll(quantity);
            return HandleQueryable<CheckingAccount>(query);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return HandleCallback(() => _accountsService.GetById(id));
        }

        //Ger extrato de uma conta
        [HttpGet]
        [Route("{id:int}/extract")]
        public IHttpActionResult GetExtracts(int id)
        {
            return HandleCallback(() => _accountsService.GetExtract(id));
        }
        #endregion HttpGet

        #region HttpPost
        [HttpPost]
        public IHttpActionResult Post(CheckingAccount account)
        {
            return HandleCallback(() => _accountsService.Add(account));
        }

        #endregion HttpPost

        #region HttpPut
        [HttpPut]
        public IHttpActionResult Update(CheckingAccount account)
        {
            return HandleCallback(() => _accountsService.Update(account));
        }

        [HttpPut]
        [Route("transfer")]
        public IHttpActionResult Transfer(AccountTransactionModel account)
        {
            return HandleCallback(() => _accountsService.Transfer(account));
        }

        [HttpPut]
        [Route("withdraw")]
        public IHttpActionResult Withdraw(AccountTransactionModel account)
        {
            return HandleCallback(() => _accountsService.Withdraw(account));
        }

        [HttpPut]
        [Route("deposit")]
        public IHttpActionResult Deposit(AccountTransactionModel account)
        {
            return HandleCallback(() => _accountsService.Deposit(account));
        }

        #endregion HttpPut

        #region HttpDelete
        [HttpDelete]
        public IHttpActionResult Delete(CheckingAccount account)
        {
            return HandleCallback(() => _accountsService.Remove(account));
        }

        #endregion HttpDelete

        #region HttpPatch
        [HttpPatch]
        [Route("status")]
        public IHttpActionResult UpdateStatus(CheckingAccount account)
        {
            return HandleCallback(() => _accountsService.UpdateStatus(account.Id));
        }

        #endregion HttpPatch
    }
}
