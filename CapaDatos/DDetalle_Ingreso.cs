using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalle_Ingreso
    {
        //Variables

        private int _IdDetalleIngreso, _IdIngreso, _IdArticulo, _StockInicial, _StockActual;
        private decimal _PrecioCompra, _PrecioVenta;
        private DateTime _FechaProduccion, _FechaVencimiento;

        //Encapsulando campos.

        public DateTime FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }
        public DateTime FechaProduccion { get => _FechaProduccion; set => _FechaProduccion = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public decimal PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public int StockActual { get => _StockActual; set => _StockActual = value; }
        public int StockInicial { get => _StockInicial; set => _StockInicial = value; }
        public int IdArticulo { get => _IdArticulo; set => _IdArticulo = value; }
        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdDetalleIngreso { get => _IdDetalleIngreso; set => _IdDetalleIngreso = value; }

        //Constructores

        public DDetalle_Ingreso()
        {

        }

        public DDetalle_Ingreso(int idDetalle_Ingreso, int idIngreso, int idArticulo, decimal precio_compra, decimal precio_venta,
            int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            this.IdDetalleIngreso = idDetalle_Ingreso;
            this.IdIngreso = idIngreso;
            this.IdArticulo = idArticulo;
            this.PrecioCompra = precio_compra;
            this.PrecioVenta = precio_venta;
            this.StockInicial = stock_inicial;
            this.StockActual = stock_actual;
            this.FechaProduccion = fecha_produccion;
            this.FechaVencimiento = fecha_vencimiento;
        }

        //Método Insertar.

        public string Insertar(DDetalle_Ingreso Detalle_Ingreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer el comando.
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_detalle_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalle_Ingreso = new SqlParameter();
                ParIdDetalle_Ingreso.ParameterName = "@idDetalleIngreso";
                ParIdDetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIdDetalle_Ingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalle_Ingreso);

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Detalle_Ingreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdArticulo = new SqlParameter();
                ParIdArticulo.ParameterName = "@idArticulo";
                ParIdArticulo.SqlDbType = SqlDbType.Int;
                ParIdArticulo.Value = Detalle_Ingreso.IdArticulo;
                SqlCmd.Parameters.Add(ParIdArticulo);

                SqlParameter ParPrecio_Compra = new SqlParameter();
                ParPrecio_Compra.ParameterName = "@precioCompra";
                ParPrecio_Compra.SqlDbType = SqlDbType.Money;
                ParPrecio_Compra.Value = Detalle_Ingreso.PrecioCompra;
                SqlCmd.Parameters.Add(ParPrecio_Compra);

                SqlParameter ParPrecio_Venta = new SqlParameter();
                ParPrecio_Venta.ParameterName = "@precioVenta";
                ParPrecio_Venta.SqlDbType = SqlDbType.Money;
                ParPrecio_Venta.Value = Detalle_Ingreso.PrecioVenta;
                SqlCmd.Parameters.Add(ParPrecio_Venta);

                SqlParameter ParStock_Actual = new SqlParameter();
                ParStock_Actual.ParameterName = "@stockActual";
                ParStock_Actual.SqlDbType = SqlDbType.Int;
                ParStock_Actual.Value = Detalle_Ingreso.StockActual;
                SqlCmd.Parameters.Add(ParStock_Actual);

                SqlParameter ParStock_Inicial = new SqlParameter();
                ParStock_Inicial.ParameterName = "@stockInicial";
                ParStock_Inicial.SqlDbType = SqlDbType.Int;
                ParStock_Inicial.Value = Detalle_Ingreso.StockInicial;
                SqlCmd.Parameters.Add(ParStock_Inicial);

                SqlParameter ParFecha_Produccion = new SqlParameter();
                ParFecha_Produccion.ParameterName = "@fechaProduccion";
                ParFecha_Produccion.SqlDbType = SqlDbType.Date;
                ParFecha_Produccion.Value = Detalle_Ingreso.FechaProduccion;
                SqlCmd.Parameters.Add(ParFecha_Produccion);

                SqlParameter ParFecha_Vencimiento = new SqlParameter();
                ParFecha_Vencimiento.ParameterName = "@fechaVencimiento";
                ParFecha_Vencimiento.SqlDbType = SqlDbType.Date;
                ParFecha_Vencimiento.Value = Detalle_Ingreso.FechaVencimiento;
                SqlCmd.Parameters.Add(ParFecha_Vencimiento);

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
