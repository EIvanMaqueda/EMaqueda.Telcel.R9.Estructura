using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Celeste.R9.Estructura.Negocio;
namespace Telcel.R9.Estructura.Presentacion.Controllers
{
    public class TelcelController : Controller
    {
        // GET: Telcel
        public ActionResult Index()
        {
            Result resultDepartamento=Departamento.GetAll();
            Result resultPuesto=Puesto.GetAll();
            Empleado empleado= new Empleado();
            empleado.Departamento=new Departamento();
            empleado.Puesto=new Puesto();
            Result result= Empleado.GetAll("");
            empleado.Empleados = result.Objects;
            empleado.Departamento.Departamentos = resultDepartamento.Objects;
            empleado.Puesto.Puestos = resultPuesto.Objects;
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Add(Empleado empleado) {
            Result result = Empleado.Add(empleado);
            ViewBag.Message = result.Message;
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Eliminar(int idEmpleado) {
            Result result=Empleado.Delete(idEmpleado);
            ViewBag.Message = result.Message;
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult Index(Empleado empleado)
        {
            Result resultDepartamento = Departamento.GetAll();
            Result resultPuesto = Puesto.GetAll();
            string nombre=empleado.Nombre;
            if (nombre==null)
            {
                nombre = "";
            }
            empleado.Departamento = new Departamento();
            empleado.Puesto = new Puesto();
            Result result = Empleado.GetAll(nombre);
            empleado.Empleados = result.Objects;
            empleado.Departamento.Departamentos = resultDepartamento.Objects;
            empleado.Puesto.Puestos = resultPuesto.Objects;
            return View(empleado);
        }
    }
}