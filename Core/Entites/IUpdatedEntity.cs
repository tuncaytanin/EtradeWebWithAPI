using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entites
{
    public interface IUpdatedEntity
    {
        int? UpdateUserId { get; set; }
        DateTime? UpdateDate { get; set; }
    }

}
