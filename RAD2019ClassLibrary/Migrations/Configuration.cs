namespace RAD2019ClassLibrary.Migrations
{
    using RAD2019ClassLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD2019ClassLibrary.RadBankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RAD2019ClassLibrary.RadBankContext context)
        {
            SeedCustomer(context);
            SeedAccountType(context);
            SeedAccounts(context);
            SeedTransactions(context);

            context.SaveChanges();
        }
        private void SeedCustomer(RadBankContext context)
        {
            context.Customers.AddOrUpdate(customer => customer.Name, new Models.Customer[]{
                new Models.Customer
                {
                    CustomerID = 1,
                    Name = "Customer 1",
                    Address = "Address for Customer 1"

                },
                new Models.Customer
                {
                    CustomerID = 2,
                    Name = "Customer 2",
                    Address = "Address for Customer 2"

                },
                new Models.Customer
                {
                    CustomerID = 3,
                    Name = "Customer 3",
                    Address = "Address for Customer 3"

                },
            });
        }
        private void SeedAccountType(RadBankContext context)
        {
            context.AccountTypes.AddOrUpdate(accountType => accountType.AccountTypeID, new Models.AccountType[]{
                new Models.AccountType
                {
                   AccountTypeID = 1,
                   TypeName = "Current",
                   Conditons = "Current Account Terms and conditions apply"
                },
                new Models.AccountType
                {
                   AccountTypeID = 2,
                   TypeName = "Savings",
                   Conditons = "Saving Account Terms and conditions apply"
                },
                new Models.AccountType
                {
                   AccountTypeID = 3,
                   TypeName = "Deposit",
                   Conditons = "Deposit Account Terms and conditions apply"
                }
            });
        }
        private void SeedAccounts(RadBankContext context)
        {
            context.Accounts.AddOrUpdate(account => account.AccountID, new Models.Account[] {
                new Models.Account
                {
                    AccountID = 1,
                    AccountName = "Current 1",
                    InceptionDate = DateTime.Parse("12/01/2002"),
                    CustomerID = 1,
                    CurrentBalance = 30000.00,
                    AccountTypeID = 1

                },
                new Models.Account
                {
                    AccountID = 2,
                    AccountName = "Current 2",
                    InceptionDate = DateTime.Parse("31/10/2004"),
                    CustomerID = 1,
                    CurrentBalance = 200000.00,
                    AccountTypeID = 1
                },
                new Models.Account
                {
                    AccountID = 3,
                    AccountName = "Deposit 1",
                    InceptionDate = DateTime.Parse("10/10/2014"),
                    CustomerID = 2,
                    CurrentBalance = 10000.00,
                    AccountTypeID = 3
                },
                new Models.Account
                {
                    AccountID = 4,
                    AccountName = "Deposit 1",
                    InceptionDate = DateTime.Parse("03/05/2011"),
                    CustomerID = 3,
                    CurrentBalance = 50000.00 ,
                    AccountTypeID = 3

                },
                new Models.Account
                {
                    AccountID = 5,
                    AccountName = "Savings 1",
                    InceptionDate = DateTime.Parse("02/02/2010"),
                    CustomerID = 2,
                    CurrentBalance = 3000.00,
                    AccountTypeID = 2

                },
                  new Models.Account
                {
                    AccountID = 6,
                    AccountName = "Current 1",
                    InceptionDate = DateTime.Parse("29/09/2004"),
                    CustomerID = 3,
                    CurrentBalance = 10000.00,
                    AccountTypeID = 1

                },
            });
        }
        private void SeedTransactions(RadBankContext context)
        {
            context.Transcations.AddOrUpdate(transaction => transaction.TransactionID, new Models.Transcations[] {
                new Models.Transcations
                {
                    TransactionID = 1,
                    TransactionType = (transactionType)0,
                    Amount = 300.00,
                    transactionDate = DateTime.Parse("18/01/2002"),
                    AccountID = 1
                },
                new Models.Transcations
                {
                    TransactionID = 2,
                    TransactionType = (transactionType)1,
                    Amount = 500.00,
                    transactionDate = DateTime.Parse("14/01/2002"),
                    AccountID = 1
                },
                new Models.Transcations
                {
                    TransactionID = 3,
                    TransactionType = (transactionType)1,
                    Amount = 300.00,
                    transactionDate = DateTime.Parse("05/11/2004"),
                    AccountID = 2
                },
                 new Models.Transcations
                {
                    TransactionID = 4,
                    TransactionType = (transactionType)0,
                    Amount = 200.00,
                    transactionDate = DateTime.Parse("05/11/2004"),
                    AccountID = 3
                },
                new Models.Transcations
                {
                    TransactionID = 5,
                    TransactionType = (transactionType)0,
                    Amount = 1000.00,
                    transactionDate = DateTime.Parse("25/10/2014"),
                    AccountID = 4
                },
                new Models.Transcations
                {
                    TransactionID = 6,
                    TransactionType = (transactionType)1,
                    Amount = 1000.00,
                    transactionDate = DateTime.Parse("14/02/2010"),
                    AccountID = 5
                },
                new Models.Transcations
                {
                    TransactionID = 7,
                    TransactionType = (transactionType)1,
                    Amount = 1000.00,
                    transactionDate = DateTime.Parse("04/10/2004"),
                    AccountID = 6
                },
            });
        }
    }
}

