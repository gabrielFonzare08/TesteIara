using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model.Base
{
    public interface ICepAPIService
    {
        [Get("/ws/{cep}/json")]
        Task<Endereco> GetAddressAsync(string cep);
 
    }
}
