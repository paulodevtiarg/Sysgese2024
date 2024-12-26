using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;
using System.Diagnostics.Metrics;

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

        public async Task<IActionResult> Incluir()
        {
            //mandas as tabelas para montar os combobox de escolha
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());

            var acessoViewModel = AcessoConverter.ToViewModel(new Acesso(), tabelas, perfis);

            return View(acessoViewModel);

        }

        public async Task<IActionResult> Editar(int id)
        {
            //mandas as tabelas para montar os combobox de escolha
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());
            var acesso = await _acessoRepository.ObterPorId(id);

            var acessoEditar = AcessoConverter.ToViewModel(acesso, tabelas, perfis);

            return View(acessoEditar);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AcessoViewModel acessoVM)
        {

            //Precisamos ver se existe um acesso com esses  dois parametros
            if (await _acessoRepository.VerificaAcesso(acessoVM.IdPerfil, acessoVM.IdTabela))
            {
                TempData["Error"] = "Ja existe um ACESSO para esse perfil com a TABELA selecionada";
                return RedirectToAction("Index");
            }

            var acessoEditar = AcessoConverter.ToModel(acessoVM);

            try
            {
                await _acessoRepository.Atualizar(acessoEditar);
                TempData["Success"] = "Registro ALTERADO com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Houve um erro ao adicionar o registro, tente novamente";
                return RedirectToAction("Index");
            }

                      

           
        }

        public async Task<IActionResult> ObterTabelasDisponiveis(int idPerfil)
        {
            // Obtenha as tabelas já associadas ao perfil
            var tabelasAssociadas = await _acessoRepository.ObterTabelasPorPerfil(idPerfil);

            // Filtre as tabelas que ainda não estão associadas
            var tabelasDisponiveis = await _tabelaRepostory.ObterTodos();
            var tabelasFiltradas = tabelasDisponiveis
                .Where(t => !tabelasAssociadas.Any(ta => ta.IdTabela == t.Id))
                .ToList();

            return Json(tabelasFiltradas.Select(t => new { t.Id, t.TabelaDesc }));
        }


        [HttpPost]
        public async Task<IActionResult> Incluir(AcessoViewModel acessoVM)
        {

            if (ModelState.IsValid && acessoVM != null)
            {
                //verificar se ja existe um acesso para a tabela informada
               
                if (await _acessoRepository.VerificaAcesso(acessoVM.IdPerfil, acessoVM.IdTabela))
                {
                    TempData["Error"] = "Ja existe um ACESSO para esse perfil com essa tabela";
                    return RedirectToAction("Index");
                }
                else
                {
                    var acessoNovo = AcessoConverter.ToModel(acessoVM);

                    try
                    {
                        await _acessoRepository.Adicionar(acessoNovo);
                        TempData["Success"] = "Registro cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                    catch (Exception)
                    {
                        TempData["Error"] = "Houve um erro ao adicionar o REGISTRO, tente novamente";
                        return RedirectToAction("Index");
                    }
                }




            }
            //mandas as tabelas para montar os combobox de escolha
            var tabelas = TabelaConverter.ToViewModel(await _tabelaRepostory.ObterTodos());
            var perfis = PerfilConverter.ToViewModel(await _perfilRepostory.ObterTodos());
            acessoVM.Tabelas = tabelas;
            acessoVM.Perfis = perfis;
            return View(acessoVM);

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

        public async Task<IActionResult> DarPermissaoTabela(int id, string field, bool? tab_v, bool? tab_i, bool? tab_a, bool? tab_e)
        {
            var obj = await _acessoRepository.ObterPorId(id);

            if (field == "TabelaVisualizar" && tab_v.HasValue && obj.TabelaVisualizar == tab_v.Value)
            {
                obj.TabelaVisualizar = !tab_v.Value;
                obj.DataAlt = DateTime.Now;
            }
            if (field == "TabelaInserir" && tab_i.HasValue && obj.TabelaInserir == tab_i.Value)
            {
                obj.TabelaInserir = !tab_i.Value;
                //alterar a data da alteração
                obj.DataAlt = DateTime.Now;
            }

            if (field == "TabelaAlterar" && tab_a.HasValue && obj.TabelaAlterar == tab_a.Value)
            {
                obj.TabelaAlterar = !tab_a.Value;
                obj.DataAlt = DateTime.Now;
            }

            if (field == "TabelaExcluir" && tab_e.HasValue && obj.TabelaExcluir == tab_e.Value)
            {
                obj.TabelaExcluir = !tab_e.Value;
                obj.DataAlt = DateTime.Now;
            }

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

            return null;
        }

        public async Task<IActionResult> Detalhar(int id)
        {
            var acesso = await _acessoRepository.ObterAcessoPorId(id);
         
            var mostrarAcesso = AcessoConverter.ToViewModel(acesso);

            return View(mostrarAcesso);
        }
    }
}
