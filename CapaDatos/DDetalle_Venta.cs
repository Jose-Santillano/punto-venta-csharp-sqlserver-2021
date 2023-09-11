using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Venta
    {
        private int _IdDetalleVenta, _IdVenta, _IdDetalleIngreso, _Cantidad;
        private decimal _PrecioVenta, _Descuento;

        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public int IdDetalleIngreso { get => _IdDetalleIngreso; set => _IdDetalleIngreso = value; }
        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public int IdDetalleVenta { get => _IdDetalleVenta; set => _IdDetalleVenta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }

        //Constructor
        public DDetalle_Venta()
        {

        }

        public DDetalle_Venta(int idDetalleVenta, int idVenta, int idDetalleIngreso, int cantidad, decimal precioVenta, decimal descuento)
        {
            this.IdDetalleVenta = idDetalleVenta;
            this.IdVenta = idVenta;
            this.IdDetalleIngreso = idDetalleIngreso;
            this.Cantidad = cantidad;
            this.PrecioVenta = precioVenta;
            this.Descuento = descuento;
        }

        //Método Insertar.

        public string Insertar(DDetalle_Venta Detalle_Venta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer el comando.
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle_Venta = new SqlParameter();
                ParIdDetalle_Venta.ParameterName = "@idDetalleVenta";
                ParIdDetalle_Venta.SqlDbType = SqlDbType.Int;
                ParIdDetalle_Venta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalle_Venta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Detalle_Venta.IdVenta;
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@idDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Value = Detalle_Venta.IdDetalleIngreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Money;
                ParCantidad.Value = Detalle_Venta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Int;
                ParPrecioVenta.Value = Detalle_Venta.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = Detalle_Venta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}
