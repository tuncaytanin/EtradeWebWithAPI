using Core.Entites.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim()
        {
            AppUserAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }
}
