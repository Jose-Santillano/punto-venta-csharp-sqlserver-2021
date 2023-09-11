using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NIngreso
    {
        public static string Insertar(int idTrabajador, int idProveedor, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv, string estado,
            DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.IdTrabajador = idTrabajador;
            Obj.IdProveedor = idProveedor;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;

            List<DDetalle_Ingreso> detalles = new List<DDetalle_Ingreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalle_Ingreso detalle = new DDetalle_Ingreso();

                detalle.IdArticulo = Convert.ToInt32(row["idArticulo"].ToString());
                detalle.PrecioCompra = Convert.ToDecimal(row["precioCompra"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["precioVenta"].ToString());
                detalle.StockInicial = Convert.ToInt32(row["stockInicial"].ToString());
                detalle.StockActual = Convert.ToInt32(row["stockInicial"].ToString());
                detalle.FechaProduccion = Convert.ToDateTime(row["fechaProduccion"].ToString());
                detalle.FechaVencimiento = Convert.ToDateTime(row["fechaVencimiento"].ToString());

                detalles.Add(detalle);
            }

            return Obj.Insertar(Obj, detalles);
        }

        public static string Anular(int idIngreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.IdIngreso = idIngreso;
            return Obj.Anular(Obj);
        }

        //El método mostrar que llama al método mostrar de la clase DCategoría de la CapaDatos.

        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //El método buscarfecha que llama al método buscarnombre de la clase DCategoría de la CapaDatos.

        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
