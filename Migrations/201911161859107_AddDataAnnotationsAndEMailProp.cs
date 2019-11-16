namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsAndEMailProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "EMail", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "EMail", c => c.String(nullable: false));
            AlterColumn("dbo.Appointments", "Description", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Doctors", "FullName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Doctors", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "FullName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Patients", "PhoneNumber", c => c.String(nullable: false));
            DropColumn("dbo.Patients", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "MyProperty", c => c.Int(nullable: false));
            AlterColumn("dbo.Patients", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Patients", "FullName", c => c.String());
            AlterColumn("dbo.Doctors", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Doctors", "FullName", c => c.String());
            AlterColumn("dbo.Appointments", "Description", c => c.String());
            DropColumn("dbo.Patients", "EMail");
            DropColumn("dbo.Doctors", "EMail");
        }
    }
}
