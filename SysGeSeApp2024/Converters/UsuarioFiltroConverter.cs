using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Converters
{
    public class UsuarioFiltroConverter
    {
        public static UsuarioFiltroEmpresasViewModel ToViewModel(UsuarioFiltroEmpresas usuarioFiltroEmpresa)
        {
            return new UsuarioFiltroEmpresasViewModel
            {
                IdUsuario = usuarioFiltroEmpresa.IdUsuario,
                IdFiltro = usuarioFiltroEmpresa.IdFiltro,
                IdEmpresa = usuarioFiltroEmpresa.IdEmpresa,
                User = usuarioFiltroEmpresa.User,
                Filtro = usuarioFiltroEmpresa.Filtro,
                Empresa = usuarioFiltroEmpresa.Empresa,
                Obs = usuarioFiltroEmpresa.Obs
            };
        }

        public static List<UsuarioFiltroEmpresasViewModel> ToViewModel(List<UsuarioFiltroEmpresas>? usuarioFiltroEmpesas)
        {
            List<UsuarioFiltroEmpresasViewModel> lista = new();
            if(usuarioFiltroEmpesas != null)
            {
                foreach(var usuarioFil in usuarioFiltroEmpesas)
                {
                    lista.Add(ToViewModel(usuarioFil));
                }
            }

            return lista;
        }

       
    }
}
