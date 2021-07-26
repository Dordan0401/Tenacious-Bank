using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tenacious.Models;
using Tenacious.Services;

namespace TenaciousBank.Controllers
{

    public class BankAcctController : ApiController
    {

        private BankAcctService CreateBankService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var bankService = new BankAcctService(userId);
            return bankService;
        }

        //Get All Accounts
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var bankService = CreateBankService();
            var accounts = bankService.GetBankAccts();
            return Ok(accounts);
        }

        //Get Individual Account
        [HttpGet]
        public IHttpActionResult GetOne(int id)
        {
            var bankService = CreateBankService();
            var account = bankService.GetBankAcctById(id);
            return Ok(account);
        }

        //Open a new account
        [HttpPost]
        public IHttpActionResult OpenAccount(BankAcctCreate model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankService = CreateBankService();

            if (!bankService.CreateBankAcct(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //DEPOSIT
        [HttpPut]
        [Route("api/BankAcct/{id}/Deposit")]
        public IHttpActionResult Deposit(BankAcctDeposit model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankService = CreateBankService();

            if (!bankService.BankAcctDeposit(model, id))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //WITHDRAWAL
        [HttpPut]
        [Route("api/BankAcct/{id}/Withdrawal")]
        public IHttpActionResult Withdraw(BankAcctWithdrawal model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankService = CreateBankService();

            if (!bankService.BankAcctWithdrawal(model, id))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //TRANSFER
        [HttpPut]
        [Route("api/BankAcct/Transfer")]
        public IHttpActionResult Transfer(BankAcctTransfer model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankService = CreateBankService();

            if (!bankService.BankAcctTransfer(model))
            {
                return InternalServerError();
            }

            return Ok();
        }

        //Close Account
        [HttpDelete]
        public IHttpActionResult DeleteAcct(int id)
        {
            var bankService = CreateBankService();

            if (!bankService.DeleteAcct(id))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
