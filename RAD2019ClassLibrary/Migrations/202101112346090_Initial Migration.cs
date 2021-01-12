namespace RAD2019ClassLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        InceptionDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CurrentBalance = c.Double(nullable: false),
                        AccountTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountID)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.AccountTypeID);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        AccountTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Conditons = c.String(),
                    })
                .PrimaryKey(t => t.AccountTypeID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Transactons",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        transactionDate = c.DateTime(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("dbo.Account", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactons", "AccountID", "dbo.Account");
            DropForeignKey("dbo.Account", "CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Account", "AccountTypeID", "dbo.AccountType");
            DropIndex("dbo.Transactons", new[] { "AccountID" });
            DropIndex("dbo.Account", new[] { "AccountTypeID" });
            DropIndex("dbo.Account", new[] { "CustomerID" });
            DropTable("dbo.Transactons");
            DropTable("dbo.Customer");
            DropTable("dbo.AccountType");
            DropTable("dbo.Account");
        }
    }
}
