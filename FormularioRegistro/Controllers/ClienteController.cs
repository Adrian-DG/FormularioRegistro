using FormularioRegistro.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormularioRegistro.Controllers
{
    public class ClienteController : Controller
    {
       

        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

       [HttpPost]
       public ActionResult CrearCliente(Cliente cliente)
       {
            string filename = Path.GetFileNameWithoutExtension(cliente.ImageFile.FileName);
            string extension = Path.GetExtension(cliente.ImageFile.FileName);

            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            cliente.ImagePath = "~/Images/" + filename;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);
            cliente.ImageFile.SaveAs(filename);

            using(ClienteContext db = new ClienteContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            ModelState.Clear();

            return RedirectToAction("Index");
       }

        [HttpGet]
        public PartialViewResult MostrarClientes()
        {
            using(ClienteContext db = new ClienteContext())
            {
                return PartialView("_Mostrar", db.Clientes.ToList());
            }
        }
       
    }
    

    
}
