using ClinicManager.Models;
using ClinicManager.Repositories;
using ClinicManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Services
{
    public interface IVisitService : IVisitRepository
    {
        VisitFormViewModel GetNewVisitFormViewModel();
        VisitFormViewModel GetEditVisitFormViewModel(int id);
        void AddVisit(Visit visit);
    }
}
