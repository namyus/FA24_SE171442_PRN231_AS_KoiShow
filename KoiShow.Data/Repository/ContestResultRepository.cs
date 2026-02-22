using KoiShow.Data.Base;
using KoiShow.Data.Models;

namespace KoiShow.Data.Repository;

public class ContestResultRepository : GenericRepository<ContestResult>
{
    public ContestResultRepository()
    {
    }

    public ContestResultRepository(FA24_SE171442_PRN231_AS_KoiShowContext context) => _context = context;
}