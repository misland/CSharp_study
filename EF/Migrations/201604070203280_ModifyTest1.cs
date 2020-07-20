namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTest1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "jie", c => c.String());
            AddColumn("dbo.Tests", "sun", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "sun");
            DropColumn("dbo.Teachers", "jie");
        }
    }
}
