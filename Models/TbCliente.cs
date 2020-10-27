using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbCartaoPagamento = new HashSet<TbCartaoPagamento>();
            TbPedido = new HashSet<TbPedido>();
        }

        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("nm_cliente", TypeName = "varchar(45)")]
        public string NmCliente { get; set; }
        [Column("ds_email", TypeName = "varchar(45)")]
        public string DsEmail { get; set; }
        [Column("ds_senha", TypeName = "varchar(45)")]
        public string DsSenha { get; set; }
        [Column("nr_telefone", TypeName = "varchar(17)")]
        public string NrTelefone { get; set; }
        [Column("nr_cpf", TypeName = "varchar(14)")]
        public string NrCpf { get; set; }
        [Column("ds_cidade", TypeName = "varchar(45)")]
        public string DsCidade { get; set; }
        [Column("ds_estado", TypeName = "varchar(2)")]
        public string DsEstado { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbCartaoPagamento> TbCartaoPagamento { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbPedido> TbPedido { get; set; }
    }
}
