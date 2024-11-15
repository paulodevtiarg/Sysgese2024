using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("ACESSO")]
    public class Acesso : Entity
    {
        [Column("TABELA_ID")]
        [ForeignKey("Tabela")]
        public int IdTabela { get; set; }

        public virtual Tabela? Tabela { get; set; }

        [Column("TABELA_V")]
        public sbyte? TabelaVisualizar { get; set; }

        [Column("TABELA_I")]
        public sbyte? TabelaInserir { get; set; }

        [Column("TABELA_A")]
        public sbyte? TabelaAlterar { get; set; }

        [Column("TABELA_E")]
        public sbyte? TabelaExcluir { get; set; }

        [Column("TABELA_OBS")]
        public string TabelaObservacao { get; set; }

        [Column("PERFIL_ID")]
        [ForeignKey("Perfil")]
        public int IdPerfil { get; set; }
        public virtual Perfil? Perfil { get; set; }
    }
}
