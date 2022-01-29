using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business
{
    public interface ICotacaoItemBusiness
    {
        CotacaoItem Create(CotacaoItem item);
        CotacaoItem FindByID(long id);
        List<CotacaoItem> FindAll();
        CotacaoItem Update(CotacaoItem item);
        void Delete(long id);
    }
}
