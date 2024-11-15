using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Models;
using System.Data;

namespace SysGeSeApp2024.Converters
{
    public static class FuncaoConverter
    {
        //Converte de Model para ViewModel
        public static FuncaoViewModel ToViewModel(Funcao funcao)
        {
            return new FuncaoViewModel
            {
                Id = funcao.Id,
                Descricao = funcao.Descricao,
                Status = funcao.Status,
                DataAlt = funcao.DataAltTexto,
                DataCad = funcao.DataCadTexto

            };
        }

        //Converte de ViewModel para Model
        public static Funcao ToModel(FuncaoViewModel funcaoVm)
        {
            DateTime dataCad;
            DateTime dataAlt;

           

            if (!DateTime.TryParse(funcaoVm.DataCad, out dataCad))
            {
                dataCad = DateTime.Now;
            }
                       
            if (DateTime.TryParse(funcaoVm.DataAlt, out dataAlt))
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


            return new Funcao
            {
                Id = funcaoVm.Id,
                Descricao = funcaoVm.Descricao.ToUpper(),
                DataCad = dataCad,
                DataAlt = dataAlt,
                Status = (funcaoVm.Status == null) ? 1 : funcaoVm.Status
            };

        }

        public static List<FuncaoViewModel> ToViewModel(List<Funcao>? funcoes)
        {
            List<FuncaoViewModel> lista = new();
            if (funcoes != null)
            {
                foreach (var funcao in funcoes)
                {
                    lista.Add(ToViewModel(funcao));
                }
            }
            return lista;
        }

    }
}
