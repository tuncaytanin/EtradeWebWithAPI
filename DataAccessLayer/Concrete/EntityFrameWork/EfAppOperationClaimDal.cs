using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfAppOperationClaimDal : EfBaseRepository<AppOperationClaim, AppDbContext>, IAppOperationClaimDal
    {

    }
}
