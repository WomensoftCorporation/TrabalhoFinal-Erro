using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_cartao_pagamento")]
    public partial class TbCartaoPagamento
    {
        public TbCartaoPagamento()
        {
            TbPedido = new HashSet<TbPedido>();
        }

        [Key]
        [Column("id_cartao")]
        public int IdCartao { get; set; }
        [Column("nr_cartao", TypeName = "varchar(45)")]
        public string NrCartao { get; set; }
        [Column("nm_titular_cartao", TypeName = "varchar(45)")]
        public string NmTitularCartao { get; set; }
        [Column("nr_cpf_do_titular", TypeName = "varchar(14)")]
        public string NrCpfDoTitular { get; set; }
        [Column("dt_vencimento", TypeName = "date")]
        public DateTime? DtVencimento { get; set; }
        [Column("ds_cvc")]
        public int? DsCvc { get; set; }
        [Column("id_cliente")]
        public int? IdCliente { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbCartaoPagamento))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [InverseProperty("IdCartaoNavigation")]
        public virtual ICollection<TbPedido> TbPedido { get; set; }
    }
}
