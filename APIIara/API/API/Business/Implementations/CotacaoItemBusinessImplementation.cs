using API.Model;
using API.Repository.Generic;
using System;
using System.Collections.Generic;

namespace API.Business.Implementations
{
    public class CotacaoItemBusinessImplementation : ICotacaoItemBusiness
    {
        private readonly IRepository<CotacaoItem> _repository;

        public CotacaoItemBusinessImplementation (IRepository<CotacaoItem> repository)
        {
            _repository = repository;
        }

        public CotacaoItem Create(CotacaoItem item)
        {
            return _repository.Create(item);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<CotacaoItem> FindAll()
        {
            return _repository.FindAll();
        }

        public CotacaoItem FindByID(long id)
        {
            return _repository.FindById(id);
        }

        public CotacaoItem Update(CotacaoItem item)
        {
            return _repository.Update(item);
        }
    }
}
