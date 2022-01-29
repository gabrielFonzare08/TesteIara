using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public interface ICotacaoBusiness
    {
        Cotacao Create(Cotacao cotacao);
        Cotacao FindByID(long id);
        List<Cotacao> FindAll();
        Cotacao Update(Cotacao cotacao);
        void Delete(long id);
    }
}
