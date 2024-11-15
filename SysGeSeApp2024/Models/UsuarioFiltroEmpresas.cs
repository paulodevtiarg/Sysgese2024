using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models
{
    [Table("USER_FILTRO_EMPRESAS")]
    public class UsuarioFiltroEmpresas : Entity
    {
        [Column("USER_ID")]
        [ForeignKey("User")]
        public int IdUsuario { get; set; }
        public  UserModel? User { get; set; }

        [Column("FILTRO_ID")]
        [ForeignKey("Filtro")]
        public int IdFiltro { get; set; }
        public FiltroModel? Filtro { get; set; }

        [Column("EMPRESA_ID")]
        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public EmpresaModel? Empresa { get; set; }

        [Column("NOME_FILTRO")]
        public string Obs { get; set; }



    }
}
