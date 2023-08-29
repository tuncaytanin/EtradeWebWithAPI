using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites.BaseEntities
{
    public class CreatedUpdatedDeletedEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, ISoftDeleteEntity
    {
        public int CreatedUserId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }
        public int? UpdateUserId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
