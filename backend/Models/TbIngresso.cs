using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_ingresso")]
    public partial class TbIngresso
    {
        [Key]
        [Column("id_ingresso")]
        public int IdIngresso { get; set; }
        [Column("tp_ingresso", TypeName = "varchar(45)")]
        public string TpIngresso { get; set; }
        [Column("nr_assento")]
        public int? NrAssento { get; set; }
        [Column("id_pedido")]
        public int? IdPedido { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbIngresso))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
    }
}
