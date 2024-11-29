using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Controllers
{
    public class AcessoController : Controller
    {
        private readonly IAcessoRepository _acessoRepository;
      
        private readonly ITabelaRepository _tabelaRepostory;
        private readonly IPerfilRepository _perfilRepostory;
       
        
        public AcessoController(IAcessoRepository acessoRepository, ITabelaRepository tabelaRepository, IPerfilRepository perfilRepository)
        {
            _acessoRepository = acessoRepository;
            _tabelaRepostory = tabelaRepository;
            _perfilRepostory = perfilRepository;
                              
    }
        public async Task<IActionResult> Index(string tabdescricao, string perfil, sbyte status = 2, int paginaAtual =1, int qtdItensPagina = 10)
        {
          //ffff    

            var (Acessos, QtdTotalItens) = await _acessoRepository.ObterAcessos(tabdescricao, perfil, status, string.Empty, string.Empty, paginaAtual- 1, qtdItensPagina);
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());


            var lista = AcessoConverter.ToViewModel(Acessos);
            return View(new AcessoListViewModel(lista, tabelas, perfis, status, QtdTotalItens, paginaAtual, qtdItensPagina));

        }
    }
}
