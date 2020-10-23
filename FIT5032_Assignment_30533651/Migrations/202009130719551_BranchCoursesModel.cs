namespace FIT5032_Assignment_30533651.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BranchCoursesModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BranchCourses", "Branches_Id", "dbo.Branches");
            DropForeignKey("dbo.BranchCourses", "Courses_Id", "dbo.Courses");
            DropIndex("dbo.BranchCourses", new[] { "Branches_Id" });
            DropIndex("dbo.BranchCourses", new[] { "Courses_Id" });
            RenameColumn(table: "dbo.BranchCourses", name: "Branches_Id", newName: "BranchesId");
            RenameColumn(table: "dbo.BranchCourses", name: "Courses_Id", newName: "CoursesId");
            AlterColumn("dbo.BranchCourses", "BranchesId", c => c.Int(nullable: false));
            AlterColumn("dbo.BranchCourses", "CoursesId", c => c.Int(nullable: false));
            CreateIndex("dbo.BranchCourses", "BranchesId");
            CreateIndex("dbo.BranchCourses", "CoursesId");
            AddForeignKey("dbo.BranchCourses", "BranchesId", "dbo.Branches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BranchCourses", "CoursesId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BranchCourses", "CoursesId", "dbo.Courses");
            DropForeignKey("dbo.BranchCourses", "BranchesId", "dbo.Branches");
            DropIndex("dbo.BranchCourses", new[] { "CoursesId" });
            DropIndex("dbo.BranchCourses", new[] { "BranchesId" });
            AlterColumn("dbo.BranchCourses", "CoursesId", c => c.Int());
            AlterColumn("dbo.BranchCourses", "BranchesId", c => c.Int());
            RenameColumn(table: "dbo.BranchCourses", name: "CoursesId", newName: "Courses_Id");
            RenameColumn(table: "dbo.BranchCourses", name: "BranchesId", newName: "Branches_Id");
            CreateIndex("dbo.BranchCourses", "Courses_Id");
            CreateIndex("dbo.BranchCourses", "Branches_Id");
            AddForeignKey("dbo.BranchCourses", "Courses_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.BranchCourses", "Branches_Id", "dbo.Branches", "Id");
        }
    }
}
