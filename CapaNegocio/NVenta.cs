using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NVenta
    {
        public static string Insertar(int idCliente, int idTrabajador, DateTime fecha,
          string tipo_comprobante, string serie, string correlativo, decimal igv,
          DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.IdCliente = idCliente;
            Obj.IdTrabajador = idTrabajador;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;

            List<DDetalle_Venta> detalles = new List<DDetalle_Venta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Venta detalle = new DDetalle_Venta();

                detalle.IdDetalleIngreso = Convert.ToInt32(row["idDetalleIngreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["precioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());

                detalles.Add(detalle);
            }

            return Obj.Insertar(Obj, detalles);
        }

        public static string Eliminar(int idVenta)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idVenta;
            return Obj.Eliminar(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DVenta de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //El método buscarfecha que llama al método buscarnombre de la clase DVenta de la CapaDatos.

        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }

        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }

        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
    }
}
