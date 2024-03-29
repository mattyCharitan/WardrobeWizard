﻿using Repositories.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User> GetByEmail(string email);
    }
}
