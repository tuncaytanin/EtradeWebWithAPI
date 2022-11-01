using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameWork
{
    public class UfUserDal : EfBaseRepository<User, AppDbContext>, IUserDal
    {
    }
}
