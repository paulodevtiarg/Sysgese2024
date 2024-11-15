using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SysGeSeApp2024.Models.Enums;

namespace SysGeSeApp2024.Models
{
    [Table("FUNCAO")]
    public class Funcao : Entity
    {       

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

      


    }
}
