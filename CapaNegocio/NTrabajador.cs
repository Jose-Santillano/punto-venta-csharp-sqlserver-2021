using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTrabajador
    {
        //Métodos para comunicarnos con CapaDatos.

        //El método insertar que llama al método Insertar de la clase DTrabajador de la CapaDatos.

        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        //El método editar que llama al método editar de la clase DTrabajador de la CapaDatos.

        public static string Editar(int idtrabajador, string nombre, string apellidos, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }

        //El método eliminar que llama al método eliminar de la clase DTrabajador de la CapaDatos.

        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;

            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DTrabajador de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //El método BuscarApellidos que llama al método BuscarApellidos de la clase DTrabajador de la CapaDatos.

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);
        }

        //El método BuscarNum_Documento que llama al método BuscarNum_Documento de la clase DTrabajador de la CapaDatos.

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }

        //Método para login.

        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);
        }
    }
}
