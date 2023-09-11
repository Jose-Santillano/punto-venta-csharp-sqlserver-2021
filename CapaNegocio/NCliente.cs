using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {
        //Métodos para comunicarnos con CapaDatos.

        //El método insertar que llama al método Insertar de la clase DCliente de la CapaDatos.

        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Insertar(Obj);
        }

        //El método editar que llama al método editar de la clase DCliente de la CapaDatos.

        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Editar(Obj);
        }

        //El método eliminar que llama al método eliminar de la clase DCliente de la CapaDatos.

        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;

            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DCliente de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //El método BuscarApellidos que llama al método BuscarApellidos de la clase DCliente de la CapaDatos.

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //El método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase DCliente de la CapaDatos.

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}
