using KoiShow.Data.Base;
using KoiShow.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShow.Data.Repository
{
    public class AnimalRepository : GenericRepository<Animal>
    {
        public AnimalRepository() { }

        public AnimalRepository(FA24_SE171442_PRN231_AS_KoiShowContext context) => _context = context;
    }
}
