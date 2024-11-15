using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("SOCIOS")]
    public class SociosModel
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CNPJ")]
        public string Cnpj { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("APELIDO")]
        public string Apelido { get; set; }

        [Column("ID_EMPRESA")]
        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }

        public  EmpresaModel? Empresa { get; set; }

    }
}
