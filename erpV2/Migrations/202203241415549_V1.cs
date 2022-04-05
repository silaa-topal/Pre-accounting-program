namespace erpV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUsername = c.String(maxLength: 10, unicode: false),
                        AdminPassword = c.String(maxLength: 10, unicode: false),
                        AdminAuthority = c.String(maxLength: 10, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(maxLength: 30, unicode: false),
                        ProductBrand = c.String(maxLength: 30, unicode: false),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        ProductImage = c.String(maxLength: 250, unicode: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.SalesTransactions",
                c => new
                    {
                        SalesID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        PersonnelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SalesID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Personnels", t => t.PersonnelID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID)
                .Index(t => t.PersonnelID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 30, unicode: false),
                        CustomerSurame = c.String(maxLength: 30, unicode: false),
                        CustomerCity = c.String(maxLength: 13, unicode: false),
                        CustomerMailAddress = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Personnels",
                c => new
                    {
                        PersonnelID = c.Int(nullable: false, identity: true),
                        PersonnelName = c.String(maxLength: 30, unicode: false),
                        PersonnelSurName = c.String(maxLength: 30, unicode: false),
                        PersonnelImage = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.PersonnelID);
            
            CreateTable(
                "dbo.InvoiceItems",
                c => new
                    {
                        InvoiceItemID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceItemID)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false, identity: true),
                        InvoiceSerialNo = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        InvoiceRowNo = c.String(maxLength: 6, unicode: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        InvoiceTime = c.DateTime(nullable: false),
                        TaxOffice = c.String(maxLength: 30, unicode: false),
                        Consigner = c.String(maxLength: 30, unicode: false),
                        Recipient = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.InvoiceID);
            
            CreateTable(
                "dbo.Outgoings",
                c => new
                    {
                        OutgoingID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OutgoingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.SalesTransactions", "ProductID", "dbo.Products");
            DropForeignKey("dbo.SalesTransactions", "PersonnelID", "dbo.Personnels");
            DropForeignKey("dbo.SalesTransactions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceID" });
            DropIndex("dbo.SalesTransactions", new[] { "PersonnelID" });
            DropIndex("dbo.SalesTransactions", new[] { "CustomerID" });
            DropIndex("dbo.SalesTransactions", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Outgoings");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceItems");
            DropTable("dbo.Personnels");
            DropTable("dbo.Customers");
            DropTable("dbo.SalesTransactions");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
        }
    }
}
