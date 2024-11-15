using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("SOCIOSV2")]
    public class SociosV2Model : Entity
    {
        [Column("CNPJ")]
        public string Cnpj { get; set; }

        [Column("IDENTIFICADOR")]
        public string Identificador { get; set; }

        [Column("QUALIFICACAO")]
        public string Qualificacao { get; set; }
    }
}
