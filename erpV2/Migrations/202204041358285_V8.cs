namespace erpV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "InvoiceTime", c => c.String(maxLength: 5, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "InvoiceTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Invoices", "Total");
        }
    }
}
