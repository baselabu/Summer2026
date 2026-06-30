using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskApi.interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
        
    }
}