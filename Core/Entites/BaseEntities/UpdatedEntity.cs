using System;

namespace Core.Entites.BaseEntities
{
    public class UpdatedEntity : IUpdatedEntity
    {
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
