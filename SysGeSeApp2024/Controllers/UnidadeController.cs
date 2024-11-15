using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;
using SysGeSeApp2024.Repositorys;

namespace SysGeSeApp2024.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IEstadoRepository _estadoRepository;

        public UnidadeController(IUnidadeRepository unidadeRepository, IEstadoRepository estadoRepository)
        {
            _unidadeRepository = unidadeRepository;
            _estadoRepository = estadoRepository;
        }

        public async Task<IActionResult> Index(string cidade, string estado, string nome, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var est = await _estadoRepository.ObterTodos();
            var (Unidades, QtdTotalItens) = await _unidadeRepository.ObterUnidades(cidade, estado, nome, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);

            var estados = EstadoConverter.ToViewModel(est);

            var lista = UnidadeConverter.ToViewModel(Unidades);

            return View(new UnidadeListViewModel(lista, estados, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }



        public async Task<IActionResult> Incluir()
        {
            var est = await _estadoRepository.ObterTodos();
                      
            var unidadeViewModel = UnidadeConverter.ToViewModel(new Unidade(), est);

            return View(unidadeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Incluir(UnidadeViewModel? unidadeVM)
        {
          

            if (ModelState.IsValid && unidadeVM != null)
            {
                var unidadeNova = UnidadeConverter.ToModel(unidadeVM);
                try
                {
                    await _unidadeRepository.Adicionar(unidadeNova);
                    TempData["Success"] = "Unidade cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o usuário, tente novamente";
                    return RedirectToAction("Index");
                }

            }
            var est = await _estadoRepository.ObterTodos();
            unidadeVM = UnidadeConverter.ToViewModel(new Unidade(), est);
            return View(unidadeVM);
        }



        public async Task<IActionResult> Editar(int id)
        {
            var unidade = await _unidadeRepository.ObterPorId(id);
                      
            var est = await _estadoRepository.ObterTodos();

            var unidadeEditar = UnidadeConverter.ToViewModel(unidade, est);

            return View(unidadeEditar);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(UnidadeViewModel unidadeVM)
        {
            var est = await _estadoRepository.ObterTodos();
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Falha para editar o Registro");
                unidadeVM.Estados = EstadoConverter.ToViewModel(est);
                return View("Editar", unidadeVM);
            }
            else
            {
                var unidadeEditar = UnidadeConverter.ToModel(unidadeVM);
                try
                {
                    await _unidadeRepository.Atualizar(unidadeEditar);
                    TempData["Success"] = "Registro ALTERADO com sucesso";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao EDITAR o registro, tente novamente";
                    return RedirectToAction("Index");
                }
            }
           

        }


        public async Task<IActionResult>Detalhar(int id)
        {
            var unidade = await _unidadeRepository.ObterPorId(id);

           

            var unidadeDetalhar = UnidadeConverter.ToViewModel(unidade);

            return View(unidadeDetalhar);
        }


        public async Task<IActionResult>Deletar(int id)
        {
            //busca pelo ID
            var unidadeApagar = await _unidadeRepository.ObterPorId(id);
            var mostrarUnidade = UnidadeConverter.ToViewModel(unidadeApagar);

            return View(mostrarUnidade);
        }
        [HttpPost]
        public async Task<IActionResult> Deletar(UnidadeViewModel unidadeVM)
        {
            if (unidadeVM == null)
            {
                TempData["Error"] = "Registro não pode ser apagado, favor verificar e tentar novamente";
                return RedirectToAction("Index");

            }
            else
            {
                //Nesse ponto, o sistema deve verificar se a função está sendo usada em algum lugar no banco
                //caso não esteja ela vai continuar o fluxo de apagar, caso contrario ele retorna a mensagem de que nao pode remover



                try
                {
                    var removerUnidade = UnidadeConverter.ToModel(unidadeVM);
                    await _unidadeRepository.Remover(removerUnidade);
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

        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _unidadeRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _unidadeRepository.Atualizar(obj);
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