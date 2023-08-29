using Core.Entites;
using Core.Entites.BaseEntities;
using Core.Entites.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUser : User
    {
        public AppUser()
        {
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        public Guid RefreshToken { get; set; }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }

    }
}
