namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacher1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Teachers");
        }
    }
}
