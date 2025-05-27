using Microsoft.AspNetCore.Mvc;
using ListaTareasMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListaTareasMVC.Controllers
{
    public class TareasController : Controller
    {
        private static List<Tarea> tareas = new();

        public IActionResult Index()
        {
            return View(tareas);
        }

        [HttpPost]
        public IActionResult Agregar(string descripcion)
        {
            if (!string.IsNullOrEmpty(descripcion))
            {
                tareas.Add(new Tarea { Id = tareas.Count + 1, Descripcion = descripcion, Completada = false });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
                tareas.Remove(tarea);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Completar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
                tarea.Completada = !tarea.Completada;

            return RedirectToAction("Index");
        }
    }
}
