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

        //Get All Accounts For One User
        [HttpGet]
        public IHttpActionResult GetSome()
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
        public IHttpActionResult Deposit(BankAcctDeposit model)
        {

        }
    }
}
