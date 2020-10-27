using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_pedido")]
    public partial class TbPedido
    {
        public TbPedido()
        {
            TbIngresso = new HashSet<TbIngresso>();
        }

        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Column("qtd_meia")]
        public int? QtdMeia { get; set; }
        [Column("qtd_inteira")]
        public int? QtdInteira { get; set; }
        [Column("vl_preco", TypeName = "decimal(15,2)")]
        public decimal? VlPreco { get; set; }
        [Column("nr_parcelas")]
        public int? NrParcelas { get; set; }
        [Column("ds_nota_fiscal", TypeName = "varchar(45)")]
        public string DsNotaFiscal { get; set; }
        [Column("dt_pedido", TypeName = "datetime")]
        public DateTime? DtPedido { get; set; }
        [Column("id_cliente")]
        public int? IdCliente { get; set; }
        [Column("id_sala_filme")]
        public int? IdSalaFilme { get; set; }
        [Column("id_cartao")]
        public int? IdCartao { get; set; }

        [ForeignKey(nameof(IdCartao))]
        [InverseProperty(nameof(TbCartaoPagamento.TbPedido))]
        public virtual TbCartaoPagamento IdCartaoNavigation { get; set; }
        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbPedido))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdSalaFilme))]
        [InverseProperty(nameof(TbSalaFilme.TbPedido))]
        public virtual TbSalaFilme IdSalaFilmeNavigation { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbIngresso> TbIngresso { get; set; }
    }
}
