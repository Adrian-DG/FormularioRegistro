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
            string path = getImage(cliente);            

            cliente.ImageFile.SaveAs(path);
            cliente.ImagePath = "~/Images/" + path;

            using (ClienteContext db = new ClienteContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
            ModelState.Clear();

            return RedirectToAction("Index");
       }

        private string getImage(Cliente cliente)
        {
            string filename = Path.GetFileNameWithoutExtension(cliente.ImageFile.FileName);
            string extension = Path.GetExtension(cliente.ImageFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            filename = Path.Combine(Server.MapPath("~/Images/"), filename);

            return filename;
        }


        [HttpGet]
        public PartialViewResult MostrarClientes()
        {
            using(ClienteContext db = new ClienteContext())
            {
                return PartialView("_Mostrar", db.Clientes.ToList());
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            using(ClienteContext db = new ClienteContext())
            {
                var obj = db.Clientes.Where(x => x.ID.Equals(id)).FirstOrDefault();
                return View(obj);
            }
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            using(ClienteContext db = new ClienteContext())
            {
                var obj = db.Clientes.Where(x => x.ID.Equals(cliente.ID)).FirstOrDefault();
                obj.ImagePath = getImage(cliente);
                obj.Nombre = cliente.Nombre;
                obj.Apellido = cliente.Apellido;
                obj.Genre = cliente.Genre;
                obj.FechaNac = cliente.FechaNac;
                obj.Correo = cliente.Correo;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
       
    }
    

    
}
