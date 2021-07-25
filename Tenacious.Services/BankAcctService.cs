using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenacious.Data;
using Tenacious.Models;
using TenaciousBank.Models;

namespace Tenacious.Services
{
    public class BankAcctService
    {
        private readonly Guid _userId;

        public BankAcctService(Guid userId)
        {
            _userId = userId;
        }

        public BankAcctService() { }

        public bool CreateBankAcct(BankAcctCreate model)
        {
            var entity = new BankAcct()
            {
                AccountOwnerId = _userId,
                OwnerFirst = model.OwnerFirst,
                OwnerLast = model.OwnerLast,
                Balance = model.InitialDeposit,
                AccountType = model.AccountType
            };

            using (var context = new ApplicationDbContext())
            {
                context.Accounts.Add(entity);
                return context.SaveChanges() == 1;
            }
        }


        //Used to view all accounts for a specific user
        public List<BankAcctDetail> GetBankAccts()
        {
            using (var context = new ApplicationDbContext())
            {
                var accounts = context
                                .Accounts
                                .Where(a => a.AccountOwnerId == _userId);

                var accountDetail = accounts
                                    .Select(a =>
                                    new BankAcctDetail
                                    {
                                        OwnerName = a.OwnerName,
                                        AccountNumber = a.AccountNumber,
                                        Balance = a.Balance,
                                        AccountType = a.AccountType
                                    });

                return accountDetail.ToList();
            }
        }

        //Used to manage an individual account (deposit, withdrawal, transfer, etc.)
        public BankAcctDetail GetBankAcctById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var account = context
                              .Accounts
                              .Single(a => a.AccountNumber == id);

                return new BankAcctDetail()
                {
                    AccountNumber = account.AccountNumber,
                    OwnerName = account.OwnerName,
                    AccountType = account.AccountType,
                    Balance = account.Balance
                };
            }
        }

        // DEPOSIT
        public bool BankAcctDeposit(BankAcctDeposit model, int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var account = context
                              .Accounts
                              .Single(a => a.AccountNumber == id);

                account.Balance = model.NewBalance;

                return context.SaveChanges() == 1;
            }
        }

        // WITHDRAWAL
        public bool BankAcctWithdrawal(BankAcctWithdrawal model, int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var account = context
                              .Accounts
                              .Single(a => a.AccountNumber == id);

                if (account.AccountType == AccountType.IndividualInvest && model.WithdrawalAmount > 1000)
                {
                    return false;
                }

                account.Balance = model.NewBalance;

                return context.SaveChanges() == 1;
            }
        }

        // TRANSFER
        public bool BankAcctTransfer(BankAcctTransfer model)
        {
            using (var context = new ApplicationDbContext())
            {
                var sender = context
                             .Accounts
                             .Single(a => a.AccountNumber == model.SendingId);

                var reciever = context
                               .Accounts
                               .Single(a => a.AccountNumber == model.RecievingId);

                decimal senderBalanceCheck = sender.Balance - model.TransferAmount;

                if (senderBalanceCheck > 0)
                {
                    sender.Balance = senderBalanceCheck;
                    reciever.Balance += model.TransferAmount;

                    return context.SaveChanges() >= 1;
                }

                return false;
            }
        }
    }
}
