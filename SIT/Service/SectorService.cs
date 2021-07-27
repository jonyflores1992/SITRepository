using SIT.IService;
using SIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.Service
{
    public class SectorService : ISectorService
    {
        private readonly UserContext _context;

        public SectorService(UserContext context)
        {
            _context = context;
        }
        public Sector getSavedStocto()
        {
            return _context.Sector.SingleOrDefault();
        }

        public Sector Save(Sector oSector)
        {
            _context.Sector.Add(oSector);
            _context.SaveChanges();
            return oSector;
        }
    }

}
