namespace EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CId)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        SId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.SId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "StudentId" });
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
