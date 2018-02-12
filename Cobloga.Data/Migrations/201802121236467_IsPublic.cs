namespace Cobloga.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsPublic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CbaPost", "UserId", c => c.Int());
            AddColumn("dbo.CbaPost", "IsPublic", c => c.Boolean(nullable: false));
            CreateIndex("dbo.CbaPost", "UserId");
            AddForeignKey("dbo.CbaPost", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CbaPost", "UserId", "dbo.User");
            DropIndex("dbo.CbaPost", new[] { "UserId" });
            DropColumn("dbo.CbaPost", "IsPublic");
            DropColumn("dbo.CbaPost", "UserId");
            DropTable("dbo.User");
        }
    }
}
