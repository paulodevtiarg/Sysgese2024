using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Models;
using System.Net.NetworkInformation;
namespace SysGeSeApp2024.Converters
{
    public static class TabelaConverter
    {
        public static TabelaViewModel ToViewModel(Tabela tabela)
        {
            return new TabelaViewModel
            {
                Id = tabela.Id,
                TabelaDesc = tabela.TabelaDesc,
                Status = tabela.Status,
                DataAlt = tabela.DataAltTexto,
                DataCad = tabela.DataCadTexto
            };
        }

        public static Tabela ToModel(TabelaViewModel tabelaVm)
        {
            DateTime dataCad;
            DateTime dataAlt;



            if (!DateTime.TryParse(tabelaVm.DataCad, out dataCad))
            {
                dataCad = DateTime.Now;
            }

            if (DateTime.TryParse(tabelaVm.DataAlt, out dataAlt))
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

            return new Tabela
            {
                Id = tabelaVm.Id,
                TabelaDesc = tabelaVm.TabelaDesc,
                DataAlt = dataAlt,
                DataCad = dataCad,
                Status = (tabelaVm.Status == null) ? 1 : tabelaVm.Status

            };

        }

        public static List<TabelaViewModel> ToViewModel(List<Tabela>? tabelas)
        {
            List<TabelaViewModel> lista = new();
            if(tabelas != null)
            {
                foreach (var tabela in tabelas)
                {
                    lista.Add(ToViewModel(tabela));
                }
            }
            return lista;
        }
    }
}
