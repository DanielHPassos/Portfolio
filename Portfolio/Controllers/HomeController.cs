using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Portfolio.Models;
using Newtonsoft.Json.Serialization;
using Portfolio.Models.Context;
using Portfolio.Models.Entities;


namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        ClienteRepository clienteRepository = new ClienteRepository();
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact(Mensagem m)
        {

            if (ModelState.IsValid)
            {
                EnviarMensagem em = new EnviarMensagem("daniel.hpassos@gmail.com", "daniel.hpassos@hotmail.com",
                    String.Format("Vindo do site - {0}", m.Nome), String.Format("{0}\n{1}", m.Email, m.Texto),
                    m.Nome);
                em.SubmeterEmail();
                return Json(new { mensagem = "Realizado com sucesso" });
            }

            return Json(new { mensagem = "Não válido" });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string senha)
        {

            Contexto ctx = new Contexto();

            var c = ctx.Clientes.FirstOrDefault(x => x.Login == login && x.Senha == senha);
            if (c != null)
            {
                Session.Add("User", c);
                return View("Detalhes", c);
            }
            return View();
        }

        public ActionResult LogOff()
        {
            Session.Clear();
            return View("Index");
        }

        public ActionResult Detalhes(int id)
        {
            return View(clienteRepository.Buscar(id));
        }
        public ActionResult Editar(int id)
        {
            var c = clienteRepository.Buscar(id);
            
            return View(c);
        }
        [HttpPost]
        public JsonResult EditarConfirma(Cliente c)
        {

            clienteRepository.Update(c);

            return Json(new { mensagem = "Editado com sucesso" });
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Criar(Cliente c)
        {

            clienteRepository.Add(c);
            return Json(new { mensagem = "Criado com sucesso" });
        }

        public ActionResult Deletar(int id)
        {
            var c = clienteRepository.Buscar(id);
            return View(c);
        }
        [HttpPost]
        public JsonResult DeletarConfirma(int id)
        {
            clienteRepository.Delete(clienteRepository.Buscar(id));
            return Json(new { mensagem = "Deletado com sucesso" });
        }
        [HttpGet]
        public ActionResult Listar()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarClientes()
        {
            return Json(clienteRepository.Listar(),JsonRequestBehavior.AllowGet);
        }
    }
}
