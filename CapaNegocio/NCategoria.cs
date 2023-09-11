using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ponemos la referencia de la CapaDatos.
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {
        //El método insertar que llama al método Insertar de la clase DCategoría de la CapaDatos.

        public static string Insertar(string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //El método editar que llama al método editar de la clase DCategoría de la CapaDatos.

        public static string Editar(int idCategoria, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //El método eliminar que llama al método eliminar de la clase DCategoría de la CapaDatos.

        public static string Eliminar(int idCategoria)
        {
            DCategoria Obj = new DCategoria();
            Obj.IdCategoria = idCategoria;
            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DCategoría de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }

        //El método buscarnombre que llama al método buscarnombre de la clase DCategoría de la CapaDatos.

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}
