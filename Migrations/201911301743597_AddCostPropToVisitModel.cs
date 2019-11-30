namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostPropToVisitModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Visits", "Cost", c => c.Decimal(nullable: false, storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Visits", "Cost");
        }
    }
}
