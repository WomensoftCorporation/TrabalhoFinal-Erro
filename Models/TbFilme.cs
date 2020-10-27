using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tcc20.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbSalaFilme = new HashSet<TbSalaFilme>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("nm_filme", TypeName = "varchar(45)")]
        public string NmFilme { get; set; }
        [Column("ds_genero", TypeName = "varchar(45)")]
        public string DsGenero { get; set; }
        [Column("ds_duracao", TypeName = "time")]
        public TimeSpan? DsDuracao { get; set; }
        [Column("ds_classificacao_indicativa", TypeName = "varchar(45)")]
        public string DsClassificacaoIndicativa { get; set; }
        [Column("ds_sinopse", TypeName = "varchar(350)")]
        public string DsSinopse { get; set; }
        [Column("ds_elenco", TypeName = "varchar(100)")]
        public string DsElenco { get; set; }
        [Column("ds_direcao", TypeName = "varchar(45)")]
        public string DsDirecao { get; set; }
        [Column("dt_lancamento", TypeName = "datetime")]
        public DateTime? DtLancamento { get; set; }
        [Column("ds_fim_exibicao", TypeName = "datetime")]
        public DateTime? DsFimExibicao { get; set; }
        [Column("img_cartaz", TypeName = "varchar(100)")]
        public string ImgCartaz { get; set; }
        [Column("ds_trailer", TypeName = "varchar(100)")]
        public string DsTrailer { get; set; }

        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbSalaFilme> TbSalaFilme { get; set; }
    }
}
