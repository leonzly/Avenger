using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avenger.API.ApiKey
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}
