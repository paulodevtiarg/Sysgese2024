using SysGeSeApp2024.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("UNIDADE")]
    public class Unidade : Entity
    {
        [Column("NOME")]
        public string Nome { get; set; }

        [Column("LOGRADOURO")]
        public string Logradouro { get; set; }
               

        [Column("CEP")]
        public string? Cep { get; set; }

        [Column("BAIRRO")]
        public string Bairro { get; set; }

        [Column("CIDADE")]
        public string Cidade { get; set; }


        [Column("ESTADO")]
        public string Estado { get; set; }

        [Column("CNPJ")]
        public string? Cnpj { get; set; }

        [Column("IE")]
        public string? Ie { get; set; }


        [Column("TELEFONE")]
        public string? Telefone { get; set; }

        [Column("CELULAR")]
        public string? Celular { get; set; }

        [Column("OBSERVACOES")]
        public string? Observacoes { get; set; }


        [Column("EMAIL")]
        public string? Email { get; set; }

        //Lado N do relacionamento
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Usuario> Usuario { get; set; }


    }
}
