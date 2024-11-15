using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Converters
{
    public static class PerfilConverter
    {
        //Converte de Model para ViewModel
        public static PerfilViewModel ToViewModel(Perfil perfil)
        {
            return new PerfilViewModel
            {
                Id = perfil.Id,
                Descricao = perfil.Descricao,
                Status = perfil.Status,
                DataAlt = perfil.DataAltTexto,
                DataCad = perfil.DataCadTexto

            };
        }

        //Converte de ViewModel para Model
        public static Perfil ToModel(PerfilViewModel perfilVm)
        {
            DateTime dataCad;
            DateTime dataAlt;



            if (!DateTime.TryParse(perfilVm.DataCad, out dataCad))
            {
                dataCad = DateTime.Now;
            }

            if (DateTime.TryParse(perfilVm.DataAlt, out dataAlt))
            {

                if (dataAlt.Date != DateTime.Now.Date)
                {
                    dataAlt = DateTime.Now;
                }
            }
            else
            {

                dataAlt = DateTime.Now;
            }


            return new Perfil
            {
                Id = perfilVm.Id,
                Descricao = perfilVm.Descricao.ToUpper(),
                DataCad = dataCad,
                DataAlt = dataAlt,
                Status = (perfilVm.Status == null) ? 1 : perfilVm.Status
            };

        }

        public static List<PerfilViewModel> ToViewModel(List<Perfil>? perfis)
        {
            List<PerfilViewModel> lista = new();
            if (perfis != null)
            {
                foreach (var perfil in perfis)
                {
                    lista.Add(ToViewModel(perfil));
                }
            }
            return lista;
        }

    }
}
