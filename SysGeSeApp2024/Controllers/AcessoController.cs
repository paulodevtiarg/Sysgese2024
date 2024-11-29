using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

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
        public async Task<IActionResult> Index(int? tabelaId, int? perfilId, sbyte status = 2, int paginaAtual =1, int qtdItensPagina = 10)
        {
          

            var (Acessos, QtdTotalItens) = await _acessoRepository.ObterAcessos(tabelaId, perfilId, status, string.Empty, string.Empty, paginaAtual- 1, qtdItensPagina);
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());


            var lista = AcessoConverter.ToViewModel(Acessos);
            return View(new AcessoListViewModel(lista, tabelas, perfis, tabelaId, perfilId, status, QtdTotalItens, paginaAtual, qtdItensPagina));

        }
        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _acessoRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _acessoRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }
    }
}
