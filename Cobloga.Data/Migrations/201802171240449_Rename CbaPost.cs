namespace Cobloga.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCbaPost : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CbaPost", newName: "BlogPost");
            AddColumn("dbo.BlogPost", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.User", "Password", c => c.String(maxLength: 155));
            AlterColumn("dbo.User", "Name", c => c.String(maxLength: 155));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Password", c => c.String());
            DropColumn("dbo.BlogPost", "ModifiedDate");
            RenameTable(name: "dbo.BlogPost", newName: "CbaPost");
        }
    }
}
