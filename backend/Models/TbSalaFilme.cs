using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_sala_filme")]
    public partial class TbSalaFilme
    {
        public TbSalaFilme()
        {
            TbPedido = new HashSet<TbPedido>();
        }

        [Key]
        [Column("id_sala_filme")]
        public int IdSalaFilme { get; set; }
        [Column("dt_inicio_sessao", TypeName = "datetime")]
        public DateTime? DtInicioSessao { get; set; }
        [Column("hr_termino_sessao", TypeName = "time")]
        public TimeSpan? HrTerminoSessao { get; set; }
        [Column("id_sala")]
        public int? IdSala { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbSalaFilme))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
        [ForeignKey(nameof(IdSala))]
        [InverseProperty(nameof(TbSala.TbSalaFilme))]
        public virtual TbSala IdSalaNavigation { get; set; }
        [InverseProperty("IdSalaFilmeNavigation")]
        public virtual ICollection<TbPedido> TbPedido { get; set; }
    }
}
