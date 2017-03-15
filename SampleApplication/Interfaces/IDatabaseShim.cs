using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleApplication.Models;

namespace SampleApplication.Interfaces
{
    public interface IDatabaseShim
    {
       bool Login(User user);
    }
}
