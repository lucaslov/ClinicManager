namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxAppointmentsPerDayToDoctorModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctors", "MaxAppointmentsPerDay", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctors", "MaxAppointmentsPerDay");
        }
    }
}
