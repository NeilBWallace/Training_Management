namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID)
                .ForeignKey("dbo.Instructor", t => t.InstructorID)
                .Index(t => t.InstructorID);
            
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID })
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Instructor", t => t.InstructorID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.InstructorID);
            
         //   AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));

            // Create  a department for course to point to.
            Sql("INSERT INTO dbo.Department (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
            //  default value for FK points to department created above.
            AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false, defaultValue: 1));
            //AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));





            AddColumn("dbo.Course", "Date_From", c => c.String());
            AddColumn("dbo.Course", "Date_To", c => c.String());
            AddColumn("dbo.Student", "Service_Team", c => c.String());
            AddColumn("dbo.Student", "Contact_Tel_No", c => c.String());
            AddColumn("dbo.Student", "Work_Base_Address", c => c.String());
            AddColumn("dbo.Student", "Mobile_No", c => c.String());
            AddColumn("dbo.Student", "Email_Address", c => c.String());
            AddColumn("dbo.Student", "Courier_Code_Internal_Post", c => c.String());
            AddColumn("dbo.Student", "Applicants_Name", c => c.String());
            AddColumn("dbo.Student", "Applicant_Date", c => c.String());
            AddColumn("dbo.Student", "Managers_Name", c => c.String());
            AddColumn("dbo.Student", "Managers_Date", c => c.String());
            AddColumn("dbo.Student", "Print_Managers_Name", c => c.String());
            AddColumn("dbo.Student", "Managers_Base", c => c.String());
            AddColumn("dbo.Student", "Organisation", c => c.String());
            AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Course", "DepartmentID");
            AddForeignKey("dbo.Course", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.Department", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Instructor");
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.Department", new[] { "InstructorID" });
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            AlterColumn("dbo.Course", "Title", c => c.String());
            DropColumn("dbo.Student", "Organisation");
            DropColumn("dbo.Student", "Managers_Base");
            DropColumn("dbo.Student", "Print_Managers_Name");
            DropColumn("dbo.Student", "Managers_Date");
            DropColumn("dbo.Student", "Managers_Name");
            DropColumn("dbo.Student", "Applicant_Date");
            DropColumn("dbo.Student", "Applicants_Name");
            DropColumn("dbo.Student", "Courier_Code_Internal_Post");
            DropColumn("dbo.Student", "Email_Address");
            DropColumn("dbo.Student", "Mobile_No");
            DropColumn("dbo.Student", "Work_Base_Address");
            DropColumn("dbo.Student", "Contact_Tel_No");
            DropColumn("dbo.Student", "Service_Team");
            DropColumn("dbo.Course", "Date_To");
            DropColumn("dbo.Course", "Date_From");
            DropColumn("dbo.Course", "DepartmentID");
            DropTable("dbo.CourseInstructor");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.Instructor");
            DropTable("dbo.Department");
        }
    }
}
