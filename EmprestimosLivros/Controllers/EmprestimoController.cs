using ClosedXML.Excel;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using EmprestimosLivros.Services.EmprestimoService;
using EmprestimosLivros.Services.SessaoService;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EmprestimosLivros.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly ISessaoInterface _sessaoInterface;
        private readonly IEmprestimosInterface _emprestimosInterface;

        public EmprestimoController(IEmprestimosInterface emprestimosInterface, ISessaoInterface sessaoInterface)
        {
            _sessaoInterface = sessaoInterface;
            _emprestimosInterface = emprestimosInterface;
        }

        public async Task<IActionResult> Index()
        {
            var usuario = _sessaoInterface.BuscarSessao();

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Obtenha a resposta, mas passe apenas os dados (Lista de empréstimos)
            var response = await _emprestimosInterface.BuscarEmprestimos();
            var emprestimos = response.Dados; // Supondo que 'Dados' seja a lista de EmprestimosModel

            return View(emprestimos); // Passa apenas a lista de empréstimos para a view
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            var usuario = _sessaoInterface.BuscarSessao();

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();
            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var emprestimo = await _emprestimosInterface.BuscarEmprestimoPorId(id);

            return View(emprestimo.Dados);
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int? id)
        {
            var usuario = _sessaoInterface.BuscarSessao();

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var emprestimo = await _emprestimosInterface.BuscarEmprestimoPorId(id);

            return View(emprestimo.Dados);
        }

        public async Task<IActionResult> Exportar()
        {
            var dt = await _emprestimosInterface.BuscaDadosEmprestimosExcel();

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dt, "Dados Empréstimo");
                
                ws.Column(3).Style.DateFormat.Format = "dd/MM/yyyy";

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Emprestimos.xlsx");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoResult = await _emprestimosInterface.CadastrarEmprestimo(emprestimo);

                if (emprestimoResult.Status)
                {
                    TempData["MensagemSucesso"] = emprestimoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = emprestimoResult.Mensagem;
                    return View(emprestimo);
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                var emprestimoResult = await _emprestimosInterface.EditarEmprestimo(emprestimo);

                if (emprestimoResult.Status)
                {
                    TempData["MensagemSucesso"] = emprestimoResult.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = emprestimoResult.Mensagem;
                    return View(emprestimo);
                }

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Ocorreu um erro na edição!";
            return View(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                TempData["MensagemErro"] = "Empréstimo não localizado.";
                return RedirectToAction("Index"); 
            }

            var empresaResult = await _emprestimosInterface.RemoveEmprestimo(emprestimo);

            if (empresaResult.Status)
            {
                TempData["MensagemSucesso"] = empresaResult.Mensagem;
                return RedirectToAction("Index"); 
            }
            else
            {
                TempData["MensagemErro"] = empresaResult.Mensagem;
                return RedirectToAction("Index"); 
            }
        }

    }
}
