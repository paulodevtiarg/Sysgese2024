using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Converters
{
    public static class EmpresaConverter
    {
        public static EmpresaViewModel ToViewModel(EmpresaModel empresaModel)
        {
            return new EmpresaViewModel
            {
                Id = empresaModel.Id,
                Cnpj = empresaModel.Cnpj,
                Nome = empresaModel.Nome,
                Socios = empresaModel.Socios
            };

        }
        public static List<EmpresaViewModel> ToViewModel(List<EmpresaModel>? empresas, List<SociosV2Model> socios)
        {
            List<EmpresaViewModel> lista = new();
            if (empresas != null)
            {
                foreach (var empresa in empresas)
                {
                    empresa.Socios = new List<SociosV2Model>();
                    foreach(var socio in socios)
                    {
                        if (socio.Cnpj.Equals(empresa.Cnpj))
                        {
                            empresa.Socios.Add(socio);
                        }
                    }

                    lista.Add(ToViewModel(empresa));
                }
            }
            return lista;
        }


    }
}
