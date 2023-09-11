using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {
        //El método insertar que llama al método Insertar de la clase DPresentacion de la CapaDatos.

        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //El método editar que llama al método editar de la clase DPresentacion de la CapaDatos.

        public static string Editar(int idPresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idPresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //El método eliminar que llama al método eliminar de la clase DPresentacion de la CapaDatos.

        public static string Eliminar(int idPresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idPresentacion;
            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DPresentacion de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //El método buscarnombre que llama al método buscarnombre de la clase DPresentacion de la CapaDatos.

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
