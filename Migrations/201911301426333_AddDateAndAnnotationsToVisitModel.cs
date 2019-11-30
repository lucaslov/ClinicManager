namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndAnnotationsToVisitModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Visits", "Diagnosis", c => c.String(nullable: false));
            AlterColumn("dbo.Visits", "Prescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "Prescription", c => c.String());
            AlterColumn("dbo.Visits", "Diagnosis", c => c.String());
            DropColumn("dbo.Visits", "Date");
        }
    }
}
