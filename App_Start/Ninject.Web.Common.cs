[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ClinicManager.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ClinicManager.App_Start.NinjectWebCommon), "Stop")]

namespace ClinicManager.App_Start
{
    using System;
    using System.Web;
    using ClinicManager.Repositories;
    using ClinicManager.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //services
            kernel.Bind<IPatientService>().To<PatientService>();
            kernel.Bind<IDoctorService>().To<DoctorService>();
            kernel.Bind<IAppointmentService>().To<AppointmentService>();
            kernel.Bind<IVisitService>().To<VisitService>();
            //repositories
            kernel.Bind<ISpecializationRepository>().To<SpecializationRepository>();
            kernel.Bind<IDoctorRepository>().To<DoctorRepository>();
            kernel.Bind<IPatientRepository>().To<PatientRepository>();
            kernel.Bind<IVisitRepository>().To<VisitRepository>();
            kernel.Bind<IAppointmentRepository>().To<AppointmentRepository>();
        }        
    }
}