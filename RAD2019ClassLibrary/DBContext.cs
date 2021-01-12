using RAD2019ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD2019ClassLibrary
{
    public class RadBankContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transcations> Transcations { get; set; }

        public RadBankContext()
            : base("BankConnection")
        {
        }
        public static RadBankContext Create()
        {
            return new RadBankContext();
        }

    }
}
