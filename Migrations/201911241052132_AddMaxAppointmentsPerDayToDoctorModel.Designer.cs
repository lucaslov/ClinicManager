// <auto-generated />
namespace ClinicManager.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddMaxAppointmentsPerDayToDoctorModel : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddMaxAppointmentsPerDayToDoctorModel));
        
        string IMigrationMetadata.Id
        {
            get { return "201911241052132_AddMaxAppointmentsPerDayToDoctorModel"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}