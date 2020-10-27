using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_sala")]
    public partial class TbSala
    {
        public TbSala()
        {
            TbSalaFilme = new HashSet<TbSalaFilme>();
        }

        [Key]
        [Column("id_sala")]
        public int IdSala { get; set; }
        [Column("nm_sala", TypeName = "varchar(45)")]
        public string NmSala { get; set; }
        [Column("tp_sala", TypeName = "varchar(45)")]
        public string TpSala { get; set; }
        [Column("qtd_assentos_disponiveis")]
        public int? QtdAssentosDisponiveis { get; set; }
        [Column("qtd_assentos_preferencial")]
        public int? QtdAssentosPreferencial { get; set; }
        [Column("bt_acesso_cadeirante")]
        public bool? BtAcessoCadeirante { get; set; }

        [InverseProperty("IdSalaNavigation")]
        public virtual ICollection<TbSalaFilme> TbSalaFilme { get; set; }
    }
}
