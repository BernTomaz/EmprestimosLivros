using EmprestimosLivros.Dto;
using EmprestimosLivros.Services.LoginService;
using EmprestimosLivros.Services.SessaoService;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosLivros.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginInterface _loginInterface;
        private readonly ISessaoInterface _sessaoInterface;

        public LoginController(ILoginInterface loginInterface, ISessaoInterface sessaoInterface)
        {
            _loginInterface = loginInterface;
            _sessaoInterface = sessaoInterface;
        }


        public IActionResult Index()
        {

            var usuario = _sessaoInterface.BuscarSessao();

            if (usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Logout()
        {

            _sessaoInterface.RemoveSessao();
            return RedirectToAction("Index");
        }



        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegisterDto usuarioRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _loginInterface.RegistrarUsuario(usuarioRegisterDto);

                if (usuario.Status)
                {
                    TempData["MensagemSucesso"] = usuario.Mensagem;
                }
                else
                {
                    TempData["MensagemErro"] = usuario.Mensagem;
                    return View(usuarioRegisterDto);
                }

                return RedirectToAction("Index");
            }
            else
            {
                return View(usuarioRegisterDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
        {
            if (!ModelState.IsValid) // Se o modelo for inválido, retorna a View com os erros
            {
                return View("Index", usuarioLoginDto);
            }

            var usuario = await _loginInterface.LoginUsuario(usuarioLoginDto);
            if (usuario.Status)
            {
                TempData["MensagemSucesso"] = usuario.Mensagem;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["MensagemErro"] = usuario.Mensagem;
                return View("Index", usuarioLoginDto);
            }
        }
    }
}
