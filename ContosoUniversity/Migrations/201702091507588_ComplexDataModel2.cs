namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComplexDataModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Job_Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Job_Title");
        }
    }
}
