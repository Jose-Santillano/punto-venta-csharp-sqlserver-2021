using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DVenta
    {
        private int _IdVenta, _IdCliente, _IdTrabajador;
        private DateTime _Fecha;
        private string _TipoComprobante, _Serie, _Correlativo;
        private decimal _Igv;

        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string TipoComprobante { get => _TipoComprobante; set => _TipoComprobante = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public int IdCliente { get => _IdCliente; set => _IdCliente = value; }
        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }

        //Constructores

        public DVenta()
        {

        }

        public DVenta(int idVenta, int IdCliente, int idTrabajador, DateTime fecha, string tipoComprobante, string serie,
            string correlativo, decimal igv)
        {
            this.IdVenta = idVenta;
            this.IdCliente = IdCliente;
            this.IdTrabajador = idTrabajador;
            this.Fecha = fecha;
            this.TipoComprobante = tipoComprobante;
            this.Serie = Serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
        }

        //Métodos

        //Método Anular.
        public string DisminuirStock(int idDetalleIngreso, int cantidad)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código.
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando.
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdisminuir_stock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@idDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Value = idDetalleIngreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizo el stock";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public string Insertar(DVenta Venta, List<DDetalle_Venta> Detalle)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código.
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer la transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();
                //Establecer el comando.
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spinsertar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.IdCliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.IdTrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Venta.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Venta.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado.
                    this.IdVenta = Convert.ToInt32(SqlCmd.Parameters["@idVenta"].Value);

                    foreach (DDetalle_Venta det in Detalle)
                    {
                        det.IdVenta = this.IdVenta;
                        //Llamar al método insertar de la clase DDetalle_Ingreso.
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);

                        if (!rpta.Equals("OK"))
                        {
                            //Abandonamos el bucle.
                            break;
                        }
                        else
                        {
                            //Actualizar el stock.

                            rpta = DisminuirStock(det.IdDetalleIngreso, det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }
                    }
                }

                if (rpta.Equals("OK"))
                {
                    //Confirmamos la transaccion
                    SqlTra.Commit();
                }
                else
                {
                    //Negamos la transaccion.
                    SqlTra.Rollback();
                }
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar.

        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código.
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                //Establecer el comando.
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                SqlCmd.Parameters.Add(ParIdVenta);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }
        //Método Mostrar.
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                DtResultado = null;
            }
            return DtResultado;
        }
        //Método BuscarFecha.
        public DataTable BuscarFechas(string TextoBuscar, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_venta_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textoBuscar1";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textoBuscar2";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.Size = 20;
                ParTextoBuscar2.Value = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método MostrarDetalle.
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalles_venta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Método Mostrar Articulos por nombre

        public DataTable MostrarArticulo_Venta_Nombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Mostrar articulo venta por codigo

        public DataTable MostrarArticulo_Venta_Codigo(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscararticulo_venta_codigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
