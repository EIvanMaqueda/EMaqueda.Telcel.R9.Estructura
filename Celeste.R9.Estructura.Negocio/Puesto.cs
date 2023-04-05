using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.R9.Estructura.Negocio
{
    public class Puesto
    {
        public int PuestoID { get; set; }
        public string Nombre { get; set; }

        public List<object> Puestos { get; set; }
        public static Result GetAll()
        {

            Result result = new Result();
            try
            {
                using (Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities context = new Telcel.R9.Estructura.AccesoDatos.EMaquedaEstructuraEntities())
                {
                    var query = context.PuestoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            Puesto puesto = new Puesto();
                            puesto.PuestoID = obj.PuestoID;
                            puesto.Nombre = obj.Descripcion;

                            result.Objects.Add(puesto);
                        }
                        result.Correct = true;

                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
