using Core.Entites.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : UserOperationClaim
    {

        public AppUserType AppUserType { get; set; }
        public AppOperationClaim AppOperationClaim { get; set; }
        public string Status { get; set; }
    }
}
