using FastReport.Export.PdfSimple;
using Microsoft.AspNetCore.Mvc;
using SysGeSeApp2024.Converters;
using SysGeSeApp2024.Interfaces;
using SysGeSeApp2024.Models;
using SysGeSeApp2024.Models.ViewModel;

namespace SysGeSeApp2024.Controllers
{
    public class FuncaoController : Controller
    {
        private readonly IFuncaoRepository _funcaoRepository;
        private readonly IWebHostEnvironment _webHostEnv;


        public FuncaoController(IFuncaoRepository funcaoRepository, IWebHostEnvironment webHostEnv)
        {
            _funcaoRepository = funcaoRepository;
            _webHostEnv = webHostEnv;
        }

        public async Task<IActionResult> Index(string descricao, sbyte status = 2, int paginaAtual = 1, int qtdItensPagina = 5)
        {
            var (Funcoes, QtdTotalItens) = await _funcaoRepository.ObterFuncoes(descricao, status, string.Empty, string.Empty, paginaAtual - 1, qtdItensPagina);
                      

            var lista = FuncaoConverter.ToViewModel(Funcoes);

            return View(new FuncaoListViewModel(lista, status, QtdTotalItens, paginaAtual, qtdItensPagina));
        }

        [Route("CreateReport")]
        public async Task<IActionResult> CreateReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;

            var freport = new FastReport.Report();
            var funcaoList = await _funcaoRepository.ObterTodos();

            freport.Dictionary.RegisterBusinessObject(funcaoList, "funcaoList", 10, true);
            freport.Report.Save(reportFile);

            return Ok($" Relatório Gerado: {caminhoReport}");

        }

        [Route("FuncaoReport")]
        public async Task<IActionResult> FuncaoReport()
        {
            var caminhoReport = Path.Combine(_webHostEnv.WebRootPath, @"reports\ReportMvc.frx");
            var reportFile = caminhoReport;
            var freport = new FastReport.Report();
            var funcaoList = await _funcaoRepository.ObterTodos();
            freport.Report.Load(reportFile);
            freport.Dictionary.RegisterBusinessObject(funcaoList, "funcaoList", 10, true);
            freport.Prepare();
            var pdfExport = new PDFSimpleExport();

            using MemoryStream ms = new MemoryStream();
            pdfExport.Export(freport, ms);
            ms.Flush();
            return File(ms.ToArray(), "application/pdf");
            
        }

        public async Task<IActionResult> Incluir()
        {

            var funcaoViewModel =  FuncaoConverter.ToViewModel(new Funcao());
         
            return View(funcaoViewModel);
            
        }
        [HttpPost]
        public async Task<IActionResult>Incluir(FuncaoViewModel? funcaoVM)
        {
            if(ModelState.IsValid && funcaoVM != null)
            {
                var funcaoNova = FuncaoConverter.ToModel(funcaoVM);
             
                try
                {
                    await _funcaoRepository.Adicionar(funcaoNova);
                    TempData["Success"] = "Função cadastrada com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Houve um erro ao adicionar o usuário, tente novamente";
                    return RedirectToAction("Index");
                }

            }
            return View(funcaoVM);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var funcao = await _funcaoRepository.ObterPorId(id);
          
            var funcaoEditar = FuncaoConverter.ToViewModel(funcao);

            return View(funcaoEditar);
        }

        [HttpPost]
        public async Task<IActionResult>Editar(FuncaoViewModel funcaoVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Falha para editar o Registro");
                return View("Editar", funcaoVM);
            }

            var funcaoEditar = FuncaoConverter.ToModel(funcaoVM);
            try
            {
                await _funcaoRepository.Atualizar(funcaoEditar);
                TempData["Success"] = "Registro ALTERADO com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "Houve um erro ao adicionar o registro, tente novamente";
                return RedirectToAction("Index");
            }

        }

        public async Task<IActionResult> AtivarDesativar(int id)
        {
            var obj = await _funcaoRepository.ObterPorId(id);

            obj.Status = (sbyte?)((obj.Status == 1) ? 0 : 1);

            try
            {
                await _funcaoRepository.Atualizar(obj);
                return RedirectToAction("Index");
            }
            catch(Exception)
            {
                TempData["Erro"] = "Não foi possível concluír a solicitação, tente novamente";
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult>Detalhar(int id)
        {
            var funcao = await _funcaoRepository.ObterPorId(id);
            var mostrarFuncao = FuncaoConverter.ToViewModel(funcao);

            return View(mostrarFuncao);
        }

        public async Task<IActionResult>Deletar(int id)
        {
            //busca pelo ID
            var funcaoApagar = await _funcaoRepository.ObterPorId(id);
            var mostrarFuncao = FuncaoConverter.ToViewModel(funcaoApagar);

            return View(mostrarFuncao);
        }

        [HttpPost]
        public async Task<IActionResult>Deletar(FuncaoViewModel funcaoVM)
        {
            if(funcaoVM == null)
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
                    var removerFuncao = FuncaoConverter.ToModel(funcaoVM);
                    await _funcaoRepository.Remover(removerFuncao);
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
