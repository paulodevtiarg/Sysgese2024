using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

namespace SysGeSeApp2024.Controllers
{
    public class AcessoController : Controller
    {
        private readonly IAcessoRepository _acessoRepository;
        private readonly ISociosV2Repository _sociosV2Repository;
        private readonly ITabelaRepository _tabelaRepostory;
        private readonly IPerfilRepository _perfilRepostory;
        private readonly IFilltroRepository _filtroRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IUsuarioFiltroEmpresasRepository _ussuarioFiltroEmpresasRepository;
        
        public AcessoController(IAcessoRepository acessoRepository, ITabelaRepository tabelaRepository, IPerfilRepository perfilRepository, IEmpresaRepository empresaRepository, IUsuarioFiltroEmpresasRepository ussuarioFiltroEmpresasRepository, ISociosV2Repository sociosV2Repository, IFilltroRepository filtroRepository)
        {
            _acessoRepository = acessoRepository;
            _tabelaRepostory = tabelaRepository;
            _perfilRepostory = perfilRepository;
            _empresaRepository = empresaRepository;
            _ussuarioFiltroEmpresasRepository = ussuarioFiltroEmpresasRepository;
            _sociosV2Repository = sociosV2Repository;
            _filtroRepository = filtroRepository;
    }
        public async Task<IActionResult> Index(string tabdescricao, string perfil, sbyte status = 2, int paginaAtual =1, int qtdItensPagina = 5)
        {

            //  var socios = await _sociosV2Repository.ObterTodosSociosV2();

            //  var empresas = await _empresaRepository.ObterTodosEmpresas();



            // var usuarioFiltroEmpreas = await _ussuarioFiltroEmpresasRepository.ObterTodosUsuarioFiltroEmpresas();
            var filtros = await _filtroRepository.ObterTodosFiltros();


            var teste = FiltroConverter.ToViewModel(filtros);

        //    var convertirod = EmpresaConverter.ToViewModel(empresas, socios);

            var (Acessos, QtdTotalItens) = await _acessoRepository.ObterAcessos(tabdescricao, perfil, status, string.Empty, string.Empty, paginaAtual- 1, qtdItensPagina);
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());


            var lista = AcessoConverter.ToViewModel(Acessos);
            return View(new AcessoListViewModel(lista, tabelas, perfis, status, QtdTotalItens, paginaAtual, qtdItensPagina));

        }
    }
}
