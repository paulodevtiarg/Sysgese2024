using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Models;

namespace SysGeSeApp2024.Converters
{
    public static class AcessoConverter
    {
        public static AcessoViewModel ToViewModel(Acesso acesso)
        {
            return new AcessoViewModel
            {
                Id = acesso.Id,
                IdTabela = acesso.IdTabela,
                Tabela = acesso.Tabela,
                TabelaVisualizar = acesso.TabelaVisualizar,
                TabelaInserir = acesso.TabelaInserir,
                TabelaAlterar = acesso.TabelaAlterar,
                TabelaExcluir = acesso.TabelaExcluir,
                TabelaObservacao = acesso.TabelaObservacao,
                Status = acesso.Status,
                IdPerfil = acesso.IdPerfil,
                Perfil = acesso.Perfil,
                DataAlt = acesso.DataAltTexto,
                DataCad = acesso.DataCadTexto
               

            };
        }

        public static AcessoViewModel? ToViewModel(Acesso acesso, List<Tabela> tabelas, List<Perfil> perfis)
        {
            AcessoViewModel acessoViewModel = ToViewModel(acesso);
            if (acessoViewModel != null)
            {

                acessoViewModel.Tabelas = TabelaConverter.ToViewModel(tabelas);
                acessoViewModel.Perfis = PerfilConverter.ToViewModel(perfis);
            }
            return acessoViewModel;

        }

        public static AcessoViewModel? ToViewModel(Acesso acesso, List<TabelaViewModel> tabelas, List<PerfilViewModel> perfis)
        {
            AcessoViewModel acessoViewModel = ToViewModel(acesso);
            if (acessoViewModel != null)
            {

                acessoViewModel.Tabelas = tabelas;
                acessoViewModel.Perfis = perfis;
            }
            if(acessoViewModel.DataCad == null)
            {
                acessoViewModel.DataCad = DateTime.Now.ToString("dd/MM/yyyy");
            }
            if(acessoViewModel.DataAlt == null)
            {
                acessoViewModel.DataAlt = DateTime.Now.ToString("dd/MM/yyyy");
            }
            
            if(acessoViewModel.Status == null)
            {
                acessoViewModel.StatusString = "ATIVO";
            }
           
            return acessoViewModel;

        }

        public static Acesso ToModel(AcessoViewModel acessoVM)
        {
            DateTime dataCad;
            DateTime dataAlt;
            if (!DateTime.TryParse(acessoVM.DataCad, out dataCad))
            {
                dataCad = DateTime.Now;
            }

            if (DateTime.TryParse(acessoVM.DataAlt, out dataAlt))
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

            return new Acesso
            {
                Id = acessoVM.Id,
                IdTabela = acessoVM.IdTabela,
                Tabela = acessoVM.Tabela,
                TabelaVisualizar = acessoVM.TabelaVisualizar,
                TabelaInserir = acessoVM.TabelaInserir,
                TabelaAlterar = acessoVM.TabelaAlterar,
                TabelaExcluir = acessoVM.TabelaExcluir,
                TabelaObservacao = acessoVM.TabelaObservacao,
                IdPerfil = acessoVM.IdPerfil,
                Perfil = acessoVM.Perfil,
                DataAlt = dataAlt,
                DataCad = dataCad,
                Status = (acessoVM.Status == null) ? 1 : acessoVM.Status
            };
           
        }
        public static List<AcessoViewModel> ToViewModel(List<Acesso>? acessos)
        {
            List<AcessoViewModel> lista = new();
            if (acessos != null)
            {
                foreach (var acesso in acessos)
                {
                    lista.Add(ToViewModel(acesso));
                }
            }
            return lista;
        }
    }
}
