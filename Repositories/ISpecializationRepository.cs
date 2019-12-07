using ClinicManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManager.Repositories
{
    public interface ISpecializationRepository
    {
        IEnumerable<Specialization> GetAllSpecializations();
    }
}
