using SIT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIT.IService
{
    public interface ISectorService
    {
        Sector Save(Sector oSector);
        Sector getSavedStocto();
    }
}
