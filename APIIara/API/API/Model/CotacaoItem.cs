using API.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    [Table("cotacao_item")]
    public class CotacaoItem : BaseEntity
    {
        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("numero_item")]
        public int NumeroItem { get; set; }

        [Column("preco")]
        public double Preco { get; set; }

        [Column("quantidade")]
        public double Quantidade { get; set; }

        [Column("marca")]
        public string Marca { get; set; }

        [Column("unidade")]
        public string Unidade { get; set; }

        [Column("cotacao")]
        public int Cotacao { get; set; }
    }
}
