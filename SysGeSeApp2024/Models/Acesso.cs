using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("ACESSO")]
    public class Acesso : Entity
    {
        [Column("TABELA_ID")]
        [ForeignKey("Tabela")]
        public int? IdTabela { get; set; }

        public virtual Tabela? Tabela { get; set; }

        [Column("TABELA_V")]
        public bool TabelaVisualizar { get; set; } = false;

        [Column("TABELA_I")]
        public bool TabelaInserir { get; set; } = false;

        [Column("TABELA_A")]
        public bool TabelaAlterar { get; set; } = false;

        [Column("TABELA_E")]
        public bool TabelaExcluir { get; set; } = false;

        [Column("TABELA_OBS")]
        public string TabelaObservacao { get; set; }

        [Column("PERFIL_ID")]
        [ForeignKey("Perfil")]
        public int? IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }
    }
}
