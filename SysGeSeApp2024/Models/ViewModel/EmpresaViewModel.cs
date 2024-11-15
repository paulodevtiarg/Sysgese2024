using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{
    public class EmpresaListViewModel
    {
        public EmpresaListViewModel(List<EmpresaViewModel>? empresas, List<SociosV2Model> sociosV2)
        {
           Empresas = empresas;
           SociosV2 = sociosV2;
        }
       public List<EmpresaViewModel>? Empresas { get; set; }
       public List<SociosV2Model> SociosV2 { get; set; }
    }



    public class EmpresaViewModel
    {

      
        public int Id { get; set; }

       
        public string Cnpj { get; set; }

       
        public string Nome { get; set; }

        public ICollection<SociosV2Model> Socios { get; set; }

    }
}
