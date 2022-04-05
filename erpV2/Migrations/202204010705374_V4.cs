namespace erpV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Customers", "CustomerSurname", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerMailAddress", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Customers", "CustomerSurname", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(maxLength: 30, unicode: false));
        }
    }
}
