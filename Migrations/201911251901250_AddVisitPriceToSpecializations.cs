namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisitPriceToSpecializations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specializations", "VisitPrice", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specializations", "VisitPrice");
        }
    }
}
