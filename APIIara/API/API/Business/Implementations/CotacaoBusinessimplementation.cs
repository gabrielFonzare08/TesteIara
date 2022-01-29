using API.Model;
using API.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Business.Implementations
{
    public class CotacaoBusinessimplementation : ICotacaoBusiness
    {

        private readonly IRepository<Cotacao> _repository;

        public CotacaoBusinessimplementation(IRepository<Cotacao> repository)
        {
            _repository = repository;
        }


        public Cotacao Create(Cotacao cotacao)
        {
            return _repository.Create(cotacao);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Cotacao> FindAll()
        {
            return _repository.FindAll();
        }

        public Cotacao FindByID(long id)
        {
            return _repository.FindById(id);
        }

        public Cotacao Update(Cotacao cotacao)
        {
            return _repository.Update(cotacao);
        }
    }
}
