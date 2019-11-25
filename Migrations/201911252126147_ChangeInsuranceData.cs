namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInsuranceData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsInsured", c => c.Boolean(nullable: false));
            DropColumn("dbo.Patients", "InsuranceLastRenewalDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Patients", "InsuranceLastRenewalDate", c => c.DateTime());
            DropColumn("dbo.Patients", "IsInsured");
        }
    }
}
