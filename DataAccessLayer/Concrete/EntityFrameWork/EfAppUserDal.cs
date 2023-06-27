using Core.Entites.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfAppUserDal : EfBaseRepository<AppUser, AppDbContext>, IAppUserDal
    {
    }
}
