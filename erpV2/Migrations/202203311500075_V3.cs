namespace erpV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerSurname", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Customers", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "CustomerSurame");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerSurame", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Customers", "Status");
            DropColumn("dbo.Customers", "CustomerSurname");
        }
    }
}
