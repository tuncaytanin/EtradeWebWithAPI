using Core.Entites.BaseEntities;
using System;

namespace Core.Entites.Concrete
{
    public class UserOperationClaim : BaseEntity, IUpdatedEntity
    {
        public int UserTypeId { get; set; }
        public int OperationClaimId { get; set; }
        public int? UpdateUserId {get;set;}
        public DateTime? UpdateDate { get; set; }
    }
}
