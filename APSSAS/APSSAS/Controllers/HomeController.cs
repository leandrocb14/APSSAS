using APSSAS.BLL;
using APSSAS.Infraestrutura;
using APSSAS.Models;
using System.Web.Mvc;

namespace APSSAS.Controllers
{
    public class HomeController : Controller
    {
        private readonly BoCrypt boCrypt;
        public HomeController()
        {
            boCrypt = new BoCrypt();
        }
        // GET: Home
        public ActionResult Index()
        {
            UploadFileViewModel model = new UploadFileViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFile(UploadFileViewModel model)
        {
            try
            {
                return File(boCrypt.CriptografarArquivo(model), System.Net.Mime.MediaTypeNames.Application.Octet, model.File.FileName);
            }
            catch
            {
                var processo = "";
                if (model.Processo == Processo.Encrypt.DefaultValue())
                    processo = Processo.Encrypt.Description().ToLower();
                else
                    processo = Processo.Decrypt.Description().ToLower();

                TempData["ThrownException"] = string.Format("Falha ao tentar {0} o arquivo.", processo);
                return RedirectToAction("Index");
            }
            
        }
    }
}