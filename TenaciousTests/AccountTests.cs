using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Tenacious.Data;
using Tenacious.Models;
using Tenacious.Services;
using TenaciousBank.Controllers;
using TenaciousBank.Models;

namespace TenaciousTests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void TestCreateAcct()
        {
            var bankController = new BankAcctController();

            BankAcctCreate test1 = new BankAcctCreate()
            {
                OwnerFirst = "Daniel",
                OwnerLast = "Dorsey",
                InitialDeposit = 5000,
                AccountType = AccountType.IndividualInvest
            };

            IHttpActionResult actionResult = bankController.OpenAccount(test1);

            var goodResult = actionResult as OkNegotiatedContentResult<BankAcct>;

            Assert.IsNotNull(goodResult);


        }
    }
}
