namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCourse1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "ye");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ye", c => c.String());
        }
    }
}
