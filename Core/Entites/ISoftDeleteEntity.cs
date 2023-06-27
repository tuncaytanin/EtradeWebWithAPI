using System;

namespace Core.Entites
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
        int? DeletedUserId { get; set; }
        DateTime? DeletedDate { get; set; }
    }

}
