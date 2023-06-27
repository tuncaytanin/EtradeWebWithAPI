using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfAppUserTypeAppOperationClaimDal : EfBaseRepository<AppUserTypeAppOperationClaim, AppDbContext>, IAppUserTypeAppOperationClaimDal
    {

    }
}
