using System.ComponentModel.DataAnnotations;

namespace SysGeSeApp2024.Models.ViewModel
{

    
    public class EstadoViewModel
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "O campo DESCRIÇÃO é obrigatório.")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O campo UF é obrigatório.")]
        public string Uf { get; set; } = null!;

        
        public sbyte? Status { get; set; }
        public string? DataCad { get; set; }
        public string? DataAlt { get; set; }
    }
}
