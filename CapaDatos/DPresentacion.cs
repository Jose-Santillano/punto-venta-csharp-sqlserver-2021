using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idpresentacion { get { return _Idpresentacion; } set { _Idpresentacion = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }
        public string Descripcion { get { return _Descripcion; } set { _Descripcion = value; } }
        public string TextoBuscar { get { return _TextoBuscar; } set { _TextoBuscar = value; } }

        public DPresentacion()
        {

        }

        public DPresentacion(int idPresentacion, string nombre, string descripcion, string textoBuscar)
        {
            this.Idpresentacion = idPresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textoBuscar;
        }

        //Insertar
        public string Insertar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "spinsertar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";
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
        //Método Editar.
        public string Editar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "speditar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";
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
        public string Eliminar(DPresentacion Presentacion)
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
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Ejecutamos nuestro comando.
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";
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
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_presentacion";
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
        //Método BuscarNombre.
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_presentacion_nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion.TextoBuscar;
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
