using System;

namespace Core.Entites.BaseEntities
{
    public class CreatedUpdatedDeletedEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, ISoftDeleteEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
