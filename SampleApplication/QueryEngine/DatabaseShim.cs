using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApplication.Interfaces;
using SampleApplication.Models;

namespace SampleApplication.QueryEngine
{
    public class DatabaseShim : IDatabaseShim
    {
        public bool Login(User user)
        {
            /* TODO: Actual check in a local or cloud MS SQL DB */
            /* TODO: Actual check in a local or cloud NOSQL DB */
            return user.UserName.Equals(user.Password);
        }
    }
}
