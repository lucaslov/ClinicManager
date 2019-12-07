using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Repositories
{
    public interface IVisitRepository
    {
        IEnumerable<Visit> GetAllVisits();
        Visit GetVisit(int id);
        void DeleteVisit(int id);
        void AddVisitHelper(Visit visit);
        void EditVisit(Visit visit);
    }
}
