namespace erpV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personnels", "PersonnelFirstname", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Personnels", "PersonnelLastname", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Personnels", "PersonnelTitle", c => c.String(maxLength: 25, unicode: false));
            AddColumn("dbo.Personnels", "PersonnelEmailAddress", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Personnels", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Personnels", "PersonnelName");
            DropColumn("dbo.Personnels", "PersonnelSurName");
            DropColumn("dbo.Personnels", "PersonnelImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Personnels", "PersonnelImage", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Personnels", "PersonnelSurName", c => c.String(maxLength: 30, unicode: false));
            AddColumn("dbo.Personnels", "PersonnelName", c => c.String(maxLength: 30, unicode: false));
            DropColumn("dbo.Personnels", "Status");
            DropColumn("dbo.Personnels", "PersonnelEmailAddress");
            DropColumn("dbo.Personnels", "PersonnelTitle");
            DropColumn("dbo.Personnels", "PersonnelLastname");
            DropColumn("dbo.Personnels", "PersonnelFirstname");
        }
    }
}
