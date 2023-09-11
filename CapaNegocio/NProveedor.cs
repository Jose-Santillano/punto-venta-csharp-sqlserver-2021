using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProveedor
    {
        //El método insertar que llama al método Insertar de la clase DProveedor de la CapaDatos.

        public static string Insertar(string razon_proveedor, string sector_comercial, string tipo_documento,
            string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Insertar(Obj);
        }

        //El método editar que llama al método editar de la clase DProveedor de la CapaDatos.

        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial, string tipo_documento,
            string num_documento, string direccion, string telefono, string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.Razon_Social = razon_proveedor;
            Obj.Sector_Comercial = sector_comercial;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Editar(Obj);
        }

        //El método eliminar que llama al método eliminar de la clase DProveedor de la CapaDatos.

        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;

            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DProveedor de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //El método BuscarRazon_Social que llama al método buscarnombre de la clase DCategoría de la CapaDatos.

        public static DataTable BuscarRazon_Social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        //El método BuscarNum_Documento que llama al método buscarnombre de la clase DCategoría de la CapaDatos.

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
