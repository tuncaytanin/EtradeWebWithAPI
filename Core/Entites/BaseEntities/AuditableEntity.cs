using System;

namespace Core.Entites.BaseEntities
{
    public class AuditableEntity : BaseEntity, ICreatedEntity, IUpdatedEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
