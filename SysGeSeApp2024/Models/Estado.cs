using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("ESTADO")]
    public class Estado : Entity
    {
        [Column("DESCRICAO")]
        public string Descricao { get; set; } = null!;

        [Column("UF")]
        public string Uf { get; set; } = null!;

       
    }
}
