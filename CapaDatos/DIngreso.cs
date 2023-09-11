using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        //Variables.

        private int _IdIngreso, _IdTrabajador, _IdProveedor;
        private DateTime _Fecha;
        private string _TipoComprobante, _Serie, _Correlativo, _Estado;
        private decimal _Igv;

        public int IdIngreso { get => _IdIngreso; set => _IdIngreso = value; }
        public int IdTrabajador { get => _IdTrabajador; set => _IdTrabajador = value; }
        public int IdProveedor { get => _IdProveedor; set => _IdProveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string TipoComprobante { get => _TipoComprobante; set => _TipoComprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }

        //Constructores

        public DIngreso()
        {

        }

        public DIngreso(int idIngreso, int idTrabajador, int idProveedor, DateTime fecha, string tipo_comprobante, string serie,
            string correlativo, decimal igv, string estado) {

            this.IdIngreso = idIngreso;
            this.IdTrabajador = idTrabajador;
            this.IdProveedor = idProveedor;
            this.Fecha = fecha;
            this.TipoComprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;
        }

        //Métodos

        public string Insertar(DIngreso Ingreso, List<DDetalle_Ingreso> Detalle)
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
                SqlCmd.CommandText = "spinsertar_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idTrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Ingreso.IdTrabajador;
                SqlCmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.IdProveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.TipoComprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

                if (rpta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado.
                    this.IdIngreso = Convert.ToInt32(SqlCmd.Parameters["@idIngreso"].Value);

                    foreach (DDetalle_Ingreso det in Detalle)
                    {
                        det.IdIngreso = this.IdIngreso;
                        //Llamar al método insertar de la clase DDetalle_Ingreso.
                        rpta = det.Insertar(det, ref SqlCon, ref SqlTra);

                        if (!rpta.Equals("OK"))
                        {
                            //Abandonamos el bucle.
                            break;
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

        //Método Anular.
        public string Anular(DIngreso Ingreso)
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
                SqlCmd.CommandText = "spanular_ingreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.IdIngreso;
                SqlCmd.Parameters.Add(ParIdIngreso);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Anulo el Registro";
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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_ingreso";
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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_ingreso_fecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@textobuscar2";
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
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_detalles_ingreso";
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
