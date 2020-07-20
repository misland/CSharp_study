namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "bai", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "bai");
        }
    }
}
