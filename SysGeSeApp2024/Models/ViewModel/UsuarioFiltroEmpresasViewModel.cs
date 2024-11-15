using System.ComponentModel.DataAnnotations.Schema;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class UsuarioEmpresaListViewModel
    {
        public UsuarioEmpresaListViewModel(List<UsuarioFiltroEmpresasViewModel> usuarioFiltroEmpresa)
        {
            UsuarioFiltroEmpresas = usuarioFiltroEmpresa;
        }

        public List<UsuarioFiltroEmpresasViewModel> UsuarioFiltroEmpresas { get; set; }
    }
    public class UsuarioFiltroEmpresasViewModel
    {
       
        public int IdUsuario { get; set; }
        public UserModel? User { get; set; }
               
        public int IdFiltro { get; set; }
        public FiltroModel? Filtro { get; set; }
                
        public int IdEmpresa { get; set; }
        public EmpresaModel? Empresa { get; set; }
               
        public string Obs { get; set; }
    }
}
