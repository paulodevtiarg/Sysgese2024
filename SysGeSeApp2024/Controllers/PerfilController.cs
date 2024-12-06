using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

namespace SysGeSeApp2024.Controllers
{
    public class PerfilController : Controller
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }
        public async Task<IActionResult> Index(string descricao, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Perfis, QtdTotalItens) = await _perfilRepository.ObterPerfis(descricao, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);


            var lista = PerfilConverter.ToViewModel(Perfis);

            return View(new PerfilListViewModel(lista, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }
        public async Task<IActionResult> Incluir()
        {

            var perfilViewModel = PerfilConverter.ToViewModel(new Perfil());

            return View(perfilViewModel);

        }
       
        [HttpPost]
        public async Task<IActionResult> Incluir(PerfilViewModel? perfilVM)
        {
            if (ModelState.IsValid && perfilVM != null)
            {
                var perfilNovo = PerfilConverter.ToModel(perfilVM);

                try
                {
                    await _perfilRepository.Adicionar(perfilNovo);
                    TempData["Success"] = "Registro cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o REGISTRO, tente novamente";
                    return RedirectToAction("Index");
                }

            }
            return View(perfilVM);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var perfil = await _perfilRepository.ObterPorId(id);

            var perfilEditar = PerfilConverter.ToViewModel(perfil);

            return View(perfilEditar);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(PerfilViewModel perfilVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Falha para editar o Registro");
                return View("Editar", perfilVM);
            }

            var perfilEditar = PerfilConverter.ToModel(perfilVM);
            try
            {
                await _perfilRepository.Atualizar(perfilEditar);
                TempData["Success"] = "Registro ALTERADO com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Houve um erro ao adicionar o registro, tente novamente";
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> Detalhar(int id)
        {
            var perfil = await _perfilRepository.ObterPorId(id);
            var mostrarPerfil = PerfilConverter.ToViewModel(perfil);

            return View(mostrarPerfil);
        }
        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _perfilRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _perfilRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> Deletar(int id)
        {
            //busca pelo ID
            var perfilApagar = await _perfilRepository.ObterPorId(id);
            var mostrarPerfil = PerfilConverter.ToViewModel(perfilApagar);

            return View(mostrarPerfil);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(PerfilViewModel perfilVM)
        {
            if (perfilVM == null)
            {
                TempData["Error"] = "Registro não pode ser apagado, favor verificar e tentar novamente";
                return RedirectToAction("Index");

            }
            else
            {
                //Nesse ponto, o sistema deve verificar se a função está sendo usada em algum lugar no banco
                //caso não esteja ela vai continuar o fluxo de apagar, caso contrario ele retorna a mensagem de que nao pode remover

                // Verifica se a unidade está sendo usada em outro lugar no banco de dados
                //bool unidadeEmUso = await _unidadeRepository.VerificarSeUnidadeEstaEmUso(removerUnidade.Id);

                //if (unidadeEmUso)
                //{
                //    TempData["Error"] = "Registro não pode ser apagado, pois está em uso em outra parte do sistema.";
                //    return RedirectToAction("Index");
                //}


                try
                {
                    var removerPerfil = PerfilConverter.ToModel(perfilVM);
                    await _perfilRepository.Remover(removerPerfil);
                    TempData["Success"] = "Registro removido com sucesso";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Registro não pode ser apagado, favor verificar e tentar novamente";
                    return RedirectToAction("Index");
                }
            }


        }
    }
}
