﻿using Core.Entites.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAppUserDal : IBaseRepository<AppUser>
    {
    }
}
