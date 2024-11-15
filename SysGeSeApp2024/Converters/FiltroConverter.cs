using Microsoft.AspNetCore.Mvc.TagHelpers;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Converters
{
    public class FiltroConverter
    {
        public static FiltroViewModel ToViewModel(FiltroModel filtro)
        {
                      

            return new FiltroViewModel
            {
                Id = filtro.Id,
                Nome = filtro.Nome,
                Par1 = filtro.Par1,
                Par2 = filtro.Par2,
                UsuarioFiltrosViewModel = UsuarioFiltroConverter.ToViewModel((List<UsuarioFiltroEmpresas>?)filtro.UsuarioFiltros)
            };
        }

        public static List<FiltroViewModel> ToViewModel(List<FiltroModel>? filtros)
        {
            List<FiltroViewModel> lista = new();
            if (filtros != null)
            {
                foreach (var filtro in filtros)
                {
                    
                    lista.Add(ToViewModel(filtro));
                }
            }

            return lista;
        }


    }
}
