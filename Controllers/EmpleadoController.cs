using Microsoft.AspNetCore.Mvc;
using MvcChallenge.Models;
using System.Data.Entity.Core.Mapping;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MvcChallenge.Controllers
{
    public class EmpleadoController : Controller
    {

        public static List<Empleado> empList = new List<Empleado>();

   

        private EmpDBContext db = new EmpDBContext();
        
        public ActionResult Index()
        {
            var Empleados= from a in db.Empleado orderby a.Id select a;

            return View(Empleados);
        }
        
        public IActionResult Create() {
            
            return View();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await db.Empleado.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Details(int id)
        {
            var empleados1 = db.Empleado.Single(a => a.Id == id);
            return View(empleados1);
        }

        public IActionResult Delete(int id)
        {
            var empleados1 = db.Empleado.Single(a => a.Id == id);

            return View(empleados1);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            

            try
            {
                if (id != null)
                {
                    var empleados1 = db.Empleado.Single(a => a.Id == id);
                    db.Empleado.Remove(empleados1);
                    //db.SaveChanges();
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");

                }
                return View("Index");
            }
            catch (Exception)
            {

                throw;
            }
            // return View();
        }

        [HttpPost]
        public ActionResult Create(Empleado emp)
             {
                try
                 {
                     db.Empleado.Add(emp);
                     db.SaveChanges();
                     //return View();
                     return RedirectToAction("Index");
                 }
                 catch 
                 {
                     string mensaje = "Error al crear el empleado";
                     return View(mensaje);
                 }

             }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Empleado emp)
        {
            

            try
            {
                db.Empleado.AddOrUpdate(emp);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
