namespace FIT5032_Assignment_30533651.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookCoursesModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchCoursesId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.BranchCourses", t => t.BranchCoursesId, cascadeDelete: true)
                .Index(t => t.BranchCoursesId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookCourses", "BranchCoursesId", "dbo.BranchCourses");
            DropForeignKey("dbo.BookCourses", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.BookCourses", new[] { "ApplicationUserId" });
            DropIndex("dbo.BookCourses", new[] { "BranchCoursesId" });
            DropTable("dbo.BookCourses");
        }
    }
}
