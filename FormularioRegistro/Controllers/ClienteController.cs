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

            using (ClienteContext db = new ClienteContext())
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
                obj.Nombre = cliente.Nombre;
                obj.Apellido = cliente.Apellido;
                obj.Genre = cliente.Genre;
                obj.FechaNac = cliente.FechaNac;
                obj.Correo = cliente.Correo;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (ClienteContext db = new ClienteContext())
            {
                var obj = db.Clientes.Where(x => x.ID.Equals(id)).FirstOrDefault();
                return View(obj);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            using (ClienteContext db = new ClienteContext())
            {
                var obj = db.Clientes.Where(x => x.ID.Equals(cliente.ID)).FirstOrDefault();
                db.Clientes.Remove(obj);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
    
    
}
