namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicModelsToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        SpecializationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Diagnosis = c.String(),
                        Prescription = c.String(),
                        AdditionalDescription = c.String(),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.DoctorId)
                .Index(t => t.PatientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Visits", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Doctors", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Visits", new[] { "PatientId" });
            DropIndex("dbo.Visits", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "SpecializationId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropTable("dbo.Visits");
            DropTable("dbo.Patients");
            DropTable("dbo.Specializations");
            DropTable("dbo.Doctors");
            DropTable("dbo.Appointments");
        }
    }
}
