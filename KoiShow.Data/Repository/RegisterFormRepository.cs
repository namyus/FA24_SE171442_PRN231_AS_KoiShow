using KoiShow.Data.Base;
using KoiShow.Data.Models;
using KoiShow.Common.DTO.DtoResponse;
using Microsoft.EntityFrameworkCore;

namespace KoiShow.Data.Repository
{
    public class RegisterFormRepository : GenericRepository<RegisterForm>
    {
        public RegisterFormRepository() { }

        public RegisterFormRepository(FA24_SE171442_PRN231_AS_KoiShowContext context) => _context = context;

    }
}
