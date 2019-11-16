namespace ClinicManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSpecializations : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Specializations (Name) VALUES ('Allergy and Immunology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Anesthesiology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Dermatology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Diagnostic Radiology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Emergency Medicine')");
            Sql("INSERT INTO Specializations (Name) VALUES ('General Practitioner')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Internal Medicine')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Medical Genetics')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Neurology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Nuclear Medicine')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Obstetrics and Gynecology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Opthalmology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Pathology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Pediatrics')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Physical Medicine and Rehabilitation')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Preventive Medicine')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Psychiatry')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Radiation Oncology')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Surgery')");
            Sql("INSERT INTO Specializations (Name) VALUES ('Urology')");

        }
        
        public override void Down()
        {
        }
    }
}
