namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTest7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        jing = c.String(),
                    })
                .PrimaryKey(t => t.PId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tests");
        }
    }
}
