namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentToVisitModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "AppointmentId", c => c.Int());
            CreateIndex("dbo.Visits", "AppointmentId");
            AddForeignKey("dbo.Visits", "AppointmentId", "dbo.Appointments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "AppointmentId", "dbo.Appointments");
            DropIndex("dbo.Visits", new[] { "AppointmentId" });
            DropColumn("dbo.Visits", "AppointmentId");
        }
    }
}
