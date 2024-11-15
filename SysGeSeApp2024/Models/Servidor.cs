using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{

    [Table("SERVIDOR")]
    public class Servidor : Entity
    {
        [Column("NOME")]
        public string Nome { get; set; }

        [Column("MATRICULA")]
        public string Matricula { get; set; }

        [Column("LOGIN")]
        public string Login { get; set; }

        [Column("SENHA")]
        public string Senha { get; set; }

        [Column("TELEFONE")]
        public string? Telefone { get; set; }

        [Column("CELULAR")]
        public string? Celular { get; set; }

        [Column("Sexo")]
        public string? Sexo { get; set; }

        [Column("LOGRADOURO")]
        public string? Logradouro { get; set; }


        [Column("CEP")]
        public string? Cep { get; set; }

        [Column("BAIRRO")]
        public string? Bairro { get; set; }

        [Column("NUMERO")]
        public string? Numero { get; set; }


        [Column("CIDADE")]
        public string Cidade { get; set; }


        [Column("UF")]
        public string Estado { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("ID_UNIDADE")]
        [ForeignKey("Unidade")]
        public int IdUnidade { get; set; }

        public virtual Unidade? Unidade { get; set; }

        [Column("ID_PERFIL")]
        [ForeignKey("Perfil")]
        public int IdPerfil { get; set; }

        public virtual Perfil? Perfil { get; set; }

        [Column("ID_FUNCAO")]
        [ForeignKey("Funcao")]
        public int IdFuncao { get; set; }

        public virtual Funcao? Funcao { get; set; }






    }
}
