using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicManager.Models;

namespace ClinicManager.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private ApplicationDbContext _context;
        public SpecializationRepository()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Specialization> GetAllSpecializations()
        {
            var specializations = _context.Specializations;
            return specializations;
        }
    }
}