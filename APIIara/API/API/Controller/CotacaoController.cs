using API.Business;
using API.Model;
using API.Model.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class CotacaoController : ControllerBase
    {
        private readonly ILogger<CotacaoController> _logger;

        private ICotacaoBusiness _cotacaoBusiness;

        private ICotacaoItemBusiness _cotacaoitemBusiness;

        public CotacaoController(ILogger<CotacaoController> logger , ICotacaoBusiness cotacaoBusiness , ICotacaoItemBusiness cotacaoitemBusiness)
        {
            _cotacaoBusiness = cotacaoBusiness;
            _logger = logger;
            _cotacaoitemBusiness = cotacaoitemBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Cotacao> cotacoes = _cotacaoBusiness.FindAll().ToList();
            List<Cotacao> retorno = new List<Cotacao>();
            List<CotacaoItem> itens = _cotacaoitemBusiness.FindAll().ToList();

            foreach(Cotacao cots in cotacoes)
            {
                foreach (CotacaoItem itns in itens)
                {
                    if(cots.Id == itns.Cotacao)
                    {
                        cots.CotacaoItens = new List<CotacaoItem>();
                        cots.CotacaoItens.Add(itns);
                    }
                }
                retorno.Add(cots);
            }


            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            List<CotacaoItem> itens = _cotacaoitemBusiness.FindAll().ToList();
            var cotacao = _cotacaoBusiness.FindByID(id);
            if (cotacao == null) return NotFound();

            foreach (CotacaoItem itns in itens)
            {
                if (cotacao.Id == itns.Cotacao)
                {
                    cotacao.CotacaoItens = new List<CotacaoItem>();
                    cotacao.CotacaoItens.Add(itns);
                }
            }


            return Ok(cotacao);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Cotacao cotacao)
        {
            if (cotacao == null) return BadRequest();

            if(cotacao.CNPJComprador == null)
            {
                return BadRequest("O campo CNPJ Comprador não pode estar vazio!");
            }
            else
            {

                if (cotacao.CNPJComprador.Length > 18)
                {
                    return BadRequest("A informação inserida ultrapassa a limitação de caracteres do campo! Preencha novamente.");
                }
            }

            if (cotacao.CNPJFornecedor == null)
            {
                return BadRequest("O campo CNPJ Fornecedor não pode estar vazio!");
            }
            else
            {

                if (cotacao.CNPJFornecedor.Length > 18)
                {
                    return BadRequest("A informação inserida ultrapassa a limitação de caracteres do campo! Preencha novamente.");
                }
            }

            if (cotacao.NumeroCotacao == null)
            {
                return BadRequest("O campo Numero Cotacao não pode estar vazio!");
            }

            if (cotacao.DataCotacao == DateTime.MinValue)
            {
                return BadRequest("O campo Data Cotacao não pode estar vazio!");
            }

            if (cotacao.DataEntregaCotacao == DateTime.MinValue)
            {
                return BadRequest("O campo Data Entrega Cotacao não pode estar vazio!");
            }
            else
            {
                if (DateTime.Compare(cotacao.DataCotacao , cotacao.DataEntregaCotacao) > 0)
                {
                    return BadRequest("O campo Data Entrega Cotacao não pode ser menor que Data Cotacao!");
                }
            }

            if (cotacao.CEP == null)
            {
                return BadRequest("O campo CEP não pode estar vazio!");
            }
            else
            {
                if (cotacao.CEP.Length != 9)
                {
                    return BadRequest("O campo CEP deve conter 9 caracteres! Preencha corretamente.");
                }

                var cepClient = RestService.For<ICepAPIService>("https://viacep.com.br");
                var endereco = await cepClient.GetAddressAsync(cotacao.CEP);

                cotacao.Logradouro = endereco.Logradouro;
                cotacao.Complemento = endereco.Complemento;
                cotacao.Bairro = endereco.Bairro;
                cotacao.UF = endereco.UF;

            }

           List<CotacaoItem> cotacaoItemEntity = new List<CotacaoItem>();
           cotacaoItemEntity = cotacao.CotacaoItens;

            cotacao.CotacaoItens = null;

           Cotacao cotacaoEntity = _cotacaoBusiness.Create(cotacao);

            foreach (CotacaoItem item in cotacaoItemEntity) {
                item.Cotacao = (int)cotacaoEntity.Id;
                _cotacaoitemBusiness.Create(item);
            }

            cotacaoEntity.CotacaoItens = cotacaoItemEntity;

            return Ok(cotacaoEntity);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] Cotacao cotacao)
        {
            if (cotacao == null) return BadRequest();

            if (cotacao.CNPJComprador == null)
            {
                return BadRequest("O campo CNPJ Comprador não pode estar vazio!");
            }
            else
            {

                if (cotacao.CNPJComprador.Length > 18)
                {
                    return BadRequest("A informação inserida em CNPJComprador ultrapassa a limitação de caracteres do campo! Preencha novamente.");
                }
            }

            if (cotacao.CNPJFornecedor == null)
            {
                return BadRequest("O campo CNPJ Fornecedor não pode estar vazio!");
            }
            else
            {

                if (cotacao.CNPJFornecedor.Length > 18)
                {
                    return BadRequest("A informação inserida em CNPJFornecedor ultrapassa a limitação de caracteres do campo! Preencha novamente.");
                }
            }

            if (cotacao.NumeroCotacao == null)
            {
                return BadRequest("O campo Numero Cotacao não pode estar vazio!");
            }

            if (cotacao.DataCotacao == DateTime.MinValue)
            {
                return BadRequest("O campo Data Cotacao não pode estar vazio!");
            }

            if (cotacao.DataEntregaCotacao == DateTime.MinValue)
            {
                return BadRequest("O campo Data Entrega Cotacao não pode estar vazio!");
            }
            else
            {
                if (DateTime.Compare(cotacao.DataCotacao, cotacao.DataEntregaCotacao) > 0)
                {
                    return BadRequest("O campo Data Entrega Cotacao não pode ser menor que Data Cotacao!");
                }
            }

            if (cotacao.CEP == null)
            {
                return BadRequest("O campo CEP não pode estar vazio!");
            }
            else
            {
                if (cotacao.CEP.Length != 9)
                {
                    return BadRequest("O campo CEP deve conter 9 caracteres! Preencha corretamente.");
                }

                var cepClient = RestService.For<ICepAPIService>("https://viacep.com.br");
                var endereco = await cepClient.GetAddressAsync(cotacao.CEP);

                cotacao.Logradouro = endereco.Logradouro;
                cotacao.Complemento = endereco.Complemento;
                cotacao.Bairro = endereco.Bairro;
                cotacao.UF = endereco.UF;

            }

            return Ok(_cotacaoBusiness.Update(cotacao));

        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var cotacao = _cotacaoBusiness.FindByID(id);
            List<CotacaoItem> itens = _cotacaoitemBusiness.FindAll();

            foreach(CotacaoItem itns in itens)
            {
                if(cotacao.Id == itns.Cotacao)
                {
                    _cotacaoitemBusiness.Delete(itns.Id);
                }
            }

            _cotacaoBusiness.Delete(id);
            return NoContent();
        }

    }
}
