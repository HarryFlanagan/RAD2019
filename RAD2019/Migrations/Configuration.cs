namespace RAD2019.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RAD2019.Models;
    using RAD2019ClassLibrary;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RAD2019.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RAD2019.Models.ApplicationDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Branch Manager" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Data Clerk" });
            context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Customer" });

            PasswordHasher ps = new PasswordHasher();

            SeedCustomers(manager, context, ps);
            SeedBranchManager(manager, context, ps);

            context.SaveChanges();
        }
        private void SeedCustomers(UserManager<ApplicationUser> manager, ApplicationDbContext context, PasswordHasher ps)
        {
            using (RadBankContext db = new RadBankContext())
            {
                foreach (var c in db.Customers)
                {
                    context.Users.AddOrUpdate(u => u.UserName,
                    new ApplicationUser
                    {
                        UserName = c.Name,
                        Email = c.Name + "@mail.ie",
                        SecurityStamp = Guid.NewGuid().ToString(),
                        PasswordHash = ps.HashPassword("Harry$1")
                    });
                    {
                        ApplicationUser customer = manager.FindByEmail(c.Name + "@mail.ie");
                        if (customer != null)
                        {
                            manager.AddToRole(customer.Id, "Customer");
                        }

                    }
                }
            }
        }
        private void SeedBranchManager(UserManager<ApplicationUser> manager, ApplicationDbContext context, PasswordHasher ps)
        {
            context.Users.AddOrUpdate(u => u.UserName,
            new ApplicationUser
            {
                UserName = "bank.manager@bob.com",
                Email = "bank.manager@bob.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = ps.HashPassword("BobBranch$1")
            });
            {
                ApplicationUser branchManager = manager.FindByEmail("bank.manager@bob.com");
                if (branchManager != null)
                {
                    manager.AddToRole(branchManager.Id, "Branch Manager");
                }

            }
        }
    }
}