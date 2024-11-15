using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("EMPRESA")]
    public class EmpresaModel : Entity
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("ID")]
        //public int Id { get; set; }

        [Column("CNPJ")]
        public string Cnpj { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [NotMapped]
        public  ICollection<SociosV2Model> Socios { get; set; }

      

    }
}
