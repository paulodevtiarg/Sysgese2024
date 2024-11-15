using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class FiltroListViewModel 
    {
        public FiltroListViewModel(List<FiltroViewModel>? filtros) 
        { 
            Filtros = filtros;
        
        }
        public List<FiltroViewModel>? Filtros { get; set; }

    }


    public class FiltroViewModel
    {

      
        public int Id { get; set; }

        
        public string Nome { get; set; }

      
        public string Par1 { get; set; }

        public string Par2 { get; set; }

        public ICollection<UsuarioFiltroEmpresasViewModel> UsuarioFiltrosViewModel { get; set; } = new List<UsuarioFiltroEmpresasViewModel>();
    }
}
