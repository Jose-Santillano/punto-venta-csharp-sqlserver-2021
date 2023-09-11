using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmIngreso : Form
    {
        //Variables globales.
        public int idTrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private static frmIngreso _instancia;
        private decimal totalPagado = 0;

        public frmIngreso()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el articulo de compra");
            this.txtIdProveedor.Visible = false;
            this.txtIdArticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }

        //- . Inicio de los métodos . -

        //Método para controlar las instancias.
        public static frmIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmIngreso();
            }
            return _instancia;
        }

        //Método para asignar el proveedor.
        public void setProveedor(string idProveedor, string nombre)
        {
            this.txtIdProveedor.Text = idProveedor;
            this.txtProveedor.Text = nombre;
        }

        //Método para asignar el artículo.
        public void setArticulo(string idArticulo, string nombre)
        {
            this.txtIdArticulo.Text = idArticulo;
            this.txtArticulo.Text = nombre;
        }

        //Método para Mostrar mensaje de confirmación.
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método para Mostrar mensaje de error.
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para Limpiar todos los controles del formulario.

        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.txtIgv.Text = "18";
            this.crearTabla();
        }

        //Método para limpiar los detalles.
        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }

        //Método para Habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;
            this.pbBuscarArticulo.Enabled = valor;
            this.pbBuscarProveedor.Enabled = valor;
            this.pbAgregar.Enabled = valor;
            this.pbEliminar.Enabled = valor;
        }

        //Método para Habilitar los botones.
        private void Botones()
        {
            if (this.IsNuevo)
            {
                this.Habilitar(true);
                this.pbNuevo.Enabled = false;
                this.pbGuardar.Enabled = true;
                this.pbCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.pbNuevo.Enabled = true;
                this.pbGuardar.Enabled = false;
                this.pbCancelar.Enabled = false;
            }
        }

        //Método para Ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método para Mostrar.
        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para Buscar por fecha.
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFecha(this.dtFecha1.Value.ToString("yyyy-MM-dd"), 
                this.dtFecha2.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para Mostrar detalles.
        private void MostrarDetalle()
        {
            this.dtListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);
        }

        //Método para crear la tabla.
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idArticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precioCompra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stockInicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fechaProduccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fechaVencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGridView con nuestro DataTable.
            this.dtListadoDetalle.DataSource = this.dtDetalle;
        }

        //Método para guardar.
        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtIdProveedor, "Ingrese un valor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIgv, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(idTrabajador, Convert.ToInt32(this.txtIdProveedor.Text), dtFecha.Value,
                            cbTipoComprobante.Text, txtSerie.Text, txtCorrelativo.Text, Convert.ToInt32(txtIgv.Text),
                            "Emitido", dtDetalle);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro.");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para eliminar registros.
        public void eliminarRegistros()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estas seguro de que deseas eliminar los registros seleccionados?",
                    "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se anuló correctamente el ingreso.");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para agregar.

        public void agregar()
        {
            try
            {
                if (this.txtIdArticulo.Text == string.Empty || this.txtStock.Text == string.Empty ||
                    this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtStock, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idArticulo"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el artículo en el detalle.");
                        }
                    }

                    if (registrar)
                    {
                        decimal subTotal = (Convert.ToDecimal(this.txtStock.Text)) * (Convert.ToDecimal(this.txtPrecioCompra.Text));
                        totalPagado += subTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");

                        //Agregar ese detalle al dtListadoDetalle

                        DataRow row = this.dtDetalle.NewRow();
                        row["idArticulo"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["precioCompra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stockInicial"] = Convert.ToInt32(this.txtStock.Text);
                        row["fechaProduccion"] = dtFechaProduccion.Value;
                        row["fechaVencimiento"] = dtFechaVencimiento.Value;
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para eliminar fila.

        public void eliminarFila()
        {
            try
            {
                int indiceFila = this.dtListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el totalPagado.

                this.totalPagado -= Convert.ToDecimal(row["subtotal"].ToString());

                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");

                //Removemos la fila.

                this.dtDetalle.Rows.Remove(row);
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                MensajeError("No hay fila para remover.");
            }
        }

        //- . Fin de los métodos . -

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        //- . Inicio del código predeterminado . -

        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento CheckedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para asignar un CheckBox por cada fila.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento DoubleClick para transefir la información.
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idIngreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoComprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones . -

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            this.BuscarFechas();
        }

        private void pbAnular_Click(object sender, EventArgs e)
        {
            //Evento Click del pbAnular.
            this.eliminarRegistros();
        }

        private void pbBuscarArticulo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscarArticulo.
            frmVistaArticuloIngreso frm = new frmVistaArticuloIngreso();
            frm.ShowDialog();
        }

        private void pbBuscarProveedor_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscarProveedor.
            frmVistaProveedorIngreso frm = new frmVistaProveedorIngreso();
            frm.ShowDialog();
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbAgregar.
            this.agregar();
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarFila();
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbNuevo.
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtSerie.Focus();
            this.limpiarDetalle();
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbGuardar.
            this.guardar();
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbCancelar.
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        //- . Fin de los botones . -

        //- . Inicio del código obstoleto (Ignorar) . -

        private void groupBox1_Enter(object sender, EventArgs e){/*Click por error*/}
    }
}
