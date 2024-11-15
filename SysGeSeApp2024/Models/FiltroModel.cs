using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("FILTROS")]
    public class FiltroModel : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("PARAMETRO1")]
        public string Par1 { get; set; }

        [Column("PARAMETRO2")]
        public string Par2 { get; set; }

        public ICollection<UsuarioFiltroEmpresas> UsuarioFiltros { get; set; } = new List<UsuarioFiltroEmpresas>();


    }
}
