using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("PERFIL")]
    public class Perfil : Entity
    {
        [Column("DESCRICAO")]
        public string Descricao { get; set; }
    }
}
