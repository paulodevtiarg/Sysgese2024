using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("TABELA")]
    public class Tabela : Entity
    {
        [Column("TABELA")]
        public string TabelaDesc { get; set; }

       
    }
}
