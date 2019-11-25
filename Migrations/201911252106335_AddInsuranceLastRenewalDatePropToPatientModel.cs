namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInsuranceLastRenewalDatePropToPatientModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "InsuranceLastRenewalDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "InsuranceLastRenewalDate");
        }
    }
}
