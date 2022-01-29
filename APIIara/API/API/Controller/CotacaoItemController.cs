using API.Business;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controller
{
   
    public class CotacaoItemController : ControllerBase
    {
        private readonly ILogger<CotacaoItemController> _logger;

        private ICotacaoItemBusiness _cotacaoItemBusiness;

        private ICotacaoBusiness _cotacaoBusiness;


        public CotacaoItemController(ICotacaoItemBusiness cotacaoItemBusiness, ILogger<CotacaoItemController> logger , ICotacaoBusiness cotacaoBusiness)
        {
            _logger = logger;
            _cotacaoItemBusiness = cotacaoItemBusiness;
            _cotacaoBusiness = cotacaoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_cotacaoItemBusiness.FindAll().ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var item = _cotacaoItemBusiness.FindByID(id);
            if (item == null) return NotFound("O item de cotação não existe!");
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CotacaoItem item)
        {
            if (item == null) return BadRequest();

            bool naoExisteCotacao = false;

            if(item.Descricao == null)
            {
                return BadRequest("O campo Descrição é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }
            else
            {
                if(item.Descricao.Length > 255)
                {
                    return BadRequest("A informação inserida ultrapassa a limitação de caracteres do campo! Preencha novamente.");
                }
                
            }

            if(item.NumeroItem == 0)
            {
                return BadRequest("O campo NumeroItem é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }

            if(item.Quantidade == 0)
            {
                return BadRequest("O campo Quantidade é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }

            //List<Cotacao> cotacoes = _cotacaoBusiness.FindAll();

            //foreach( Cotacao cot in cotacoes)
            //{
            //    if(cot.Id != item.CotacaoId)
            //    {
            //        naoExisteCotacao = true;
            //    }
            //    else
            //    {
            //        naoExisteCotacao = false;
            //        break;
            //    }
            //}

            //if (naoExisteCotacao)
            //{
            //    return BadRequest("A cotação referenciada pela cotacao item não existe! Selecione outra.");
            //}

            

            return Ok(_cotacaoItemBusiness.Create(item));
        }

        [HttpPut]
        public IActionResult Put([FromBody] CotacaoItem item)
        {
            if (item == null) return BadRequest();

            if (item.Descricao == null)
            {
                return BadRequest("O campo Descrição é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }
            else
            {
                if (item.Descricao.Length > 255)
                {
                    return BadRequest("A informação inserida ultrapassa a limitãção de caracteres do campo! Preencha novamente.");
                }

            }

            if (item.NumeroItem == 0)
            {
                return BadRequest("O campo NumeroItem é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }

            if (item.Quantidade == 0)
            {
                return BadRequest("O campo Quantidade é obrigatório, portanto não pode estar vazio! Preencha corretamente.");
            }

            //List<Cotacao> cotacoes = _cotacaoBusiness.FindAll();

            //foreach (Cotacao cot in cotacoes)
            //{
            //    if (cot.Id != item.CotacaoId)
            //    {
            //        return BadRequest("A cotação referenciada pela cotacao item não existe! Selecione outra.");
            //    }
            //}

            return Ok(_cotacaoItemBusiness.Update(item));
        }

   
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _cotacaoItemBusiness.Delete(id);
            return NoContent();
        }

    }
}
