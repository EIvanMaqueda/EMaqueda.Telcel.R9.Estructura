using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public Departamento Departamento { get; set; }
        public Puesto Puesto { get; set; }
        public List<object> Empleados { get; set; }

        public static Result Add(Empleado empleado) {
      
           Result result= new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities())
                {

                    int query = context.EmpleadoAdd(empleado.Nombre, empleado.Departamento.DepartamentoID, empleado.Puesto.PuestoID);

                    if (query >= 1)
                    {
                        result.Correct = true;
                        result.Message = "Empleado Agregado Correctamente";
                    }
                }
            }   
            catch (Exception ex)
            {

                result.Message= ex.Message;
                result.Correct= false;
            }
            return result;
        }

        public static Result GetAll(string nombre) { 
        
            Result result= new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities context=new Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities())
                {
                    var query = context.EmpleadoGetAll(nombre).ToList();
                    if (query!=null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Empleado empleado=new Empleado();
                            empleado.Nombre= obj.Nombre;
                            empleado.EmpleadoID= obj.EmpleadoID;
                            empleado.Departamento=new Departamento();
                            empleado.Departamento.DepartamentoID = obj.EmpleadoID;
                            empleado.Departamento.Nombre = obj.NombreDepartamento;
                            empleado.Puesto=new Puesto();
                            empleado.Puesto.PuestoID = obj.PuestoID.Value;
                            empleado.Puesto.Nombre = obj.Puesto;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct= false;
                result.Message= ex.Message;
            }
            return result;
        }

        public static Result Delete(int idEmpleado) { 
        
            Result result=new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities context=new Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities())
                {
                    int query = context.EmpleadoDelete(idEmpleado);
                    if (query >=1) { 
                        result.Correct = true;
                        result.Message = "Empleado eliminado correctamente";
                    
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct= false;  
                result.Message= ex.Message;
            }
            return result;
        }
    }
}
