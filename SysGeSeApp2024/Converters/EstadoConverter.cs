using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Converters
{
    public class EstadoConverter
    {

        public static EstadoViewModel ToViewModel(Estado estado)
        {
            return new EstadoViewModel
            {
                Id = estado.Id,
                Descricao = estado.Descricao,
                Uf = estado.Uf,
                Status = estado.Status,
                DataCad = estado.DataCadTexto,
                DataAlt = estado.DataAltTexto

            };
        }

        public static List<EstadoViewModel> ToViewModel(List<Estado>? estados)
        {
            List<EstadoViewModel> lista = new();
            if (estados != null)
            {
                foreach (var estado in estados)
                {
                    lista.Add(ToViewModel(estado));
                }
            }
            return lista;
        }

    }
}
