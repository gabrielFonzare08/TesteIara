using API.Model.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table ("cotacao")]
    public class Cotacao : BaseEntity
    {
        [Column("cnpj_comprador")]
        public string CNPJComprador { get; set; }

        [Column("cnpj_fornecedor")]
        public string CNPJFornecedor { get; set; }

        [Column("numero_cotacao")]
        public string NumeroCotacao { get; set; }

        [Column("data_cotacao")]
        public DateTime DataCotacao { get; set; }

        [Column("data_entrega_cotacao")]
        public DateTime DataEntregaCotacao { get; set; }

        [Column("observacao")]
        public string Observacao { get; set; }

        [Column("cep")]
        public string CEP { get; set; }

        [Column("logradouro")]
        public string Logradouro { get; set; }

        [Column("complemento")]
        public string Complemento { get; set; }

        [Column("bairro")]
        public string Bairro{ get; set; }

        [Column("cidade")]
        public string Cidade { get; set; }

        [Column("uf")]
        public string UF { get; set; }

        [NotMapped]
        public virtual List<CotacaoItem> CotacaoItens{ get; set; }




        

    }
}
