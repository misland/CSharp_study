namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ye", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ye");
        }
    }
}
