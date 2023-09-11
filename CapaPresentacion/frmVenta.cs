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
    public partial class frmVenta : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        public int IdTrabajador;
        private DataTable dtDetalle;
        private decimal totalPagado = 0, pagoCon;
        private static frmVenta _instancia;

        public frmVenta()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un cliente.");
            this.ttMensaje.SetToolTip(this.txtSerie, "Seleccione una serie.");
            this.ttMensaje.SetToolTip(this.txtCorrelativo, "Ingrese un número de comprobante.");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Seleccione una cantidad del Articulo.");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Articulo.");
            this.txtIdArticulo.Visible = false;
            this.txtIdCliente.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.dtFechaVencimiento.Enabled = false;
            this.txtPrecioCompra.ReadOnly = true;
            this.txtStockActual.ReadOnly = true;
        }

        //- . Inicio de los métodos . -

        //Método para obtener la instancia.
        public static frmVenta GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new frmVenta();
            }
            return _instancia;
        }

        //Método para asignar nuestro cliente.
        public void SetCliente(string idCliente, string nombre)
        {
            this.txtIdCliente.Text = idCliente;
            this.txtCliente.Text = nombre;
        }

        //Método para asignar nuestro articulo.
        public void SetArticulo(string idDetalleIngreso, string nombre, decimal precioCompra, decimal PrecioVenta, int stock,
            DateTime fechaVencimiento)
        {
            this.txtIdArticulo.Text = idDetalleIngreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(precioCompra);
            this.txtPrecioVenta.Text = Convert.ToString(PrecioVenta);
            this.txtStockActual.Text = Convert.ToString(stock);
            this.dtFechaVencimiento.Value = fechaVencimiento;
        }

        //Método para asignar nuestro pago con y cambio.
        public void SetPagoCon(decimal pagoCon)
        {
            this.pagoCon = pagoCon;
            this.lblPagoCon.Text = this.pagoCon.ToString();
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
            this.txtIdVenta.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotalPagado.Text = "0.0";
            this.txtIgv.Text = "18";
            this.crearTabla();
        }

        //Método para limpiar detalles.
        private void limpiarDetalle()
        {
            this.txtIdArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStockActual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
        }

        //Método para Habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtIdVenta.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;
            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.txtStockActual.ReadOnly = !valor;
            this.txtDescuento.Text = string.Empty;
            this.dtFechaVencimiento.Enabled = valor;

            this.pbBuscarArticulo.Enabled = valor;
            this.pbBuscarCliente.Enabled = valor;
            this.pbAgregar.Enabled = valor;
            this.pbElimar.Enabled = valor;
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
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para Buscar por fecha.
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFecha(this.dtFecha1.Value.ToString("yyyy-MM-dd"),
                this.dtFecha2.Value.ToString("yyyy-MM-dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para Mostrar detalles.
        private void MostrarDetalle()
        {
            this.dtListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdVenta.Text);
        }

        //Método para crear la tabla de datos.
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idDetalleIngreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precioVenta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGridView con nuestro DataTable.
            this.dtListadoDetalle.DataSource = this.dtDetalle;
        }

        //Método para eliminar las filas seleccionadas.

        public void eliminarFilas()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas eliminar los registros seleccionados?",
                    "Sistema de ventas - (Listado)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se eliminó correctamente la venta.");
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

        //Método para guardar.

        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtIdCliente.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtIdCliente, "Ingrese un valor");
                    errorIcono.SetError(txtSerie, "Ingrese un valor");
                    errorIcono.SetError(txtCorrelativo, "Ingrese un valor");
                    errorIcono.SetError(txtIgv, "Ingrese un valor");
                }
                else
                {
                    frmEntrada_Venta frm = new frmEntrada_Venta();
                    frm.txtTotalPagar.Text = this.lblTotalPagado.Text;
                    frm.ShowDialog();
                    this.lblCambio.Text = (this.pagoCon - this.totalPagado).ToString();

                    if (this.lblTotal.Text != "0.0")
                    {
                        if (this.IsNuevo)
                        {
                            rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), IdTrabajador, dtFecha.Value,
                                cbTipoComprobante.Text, txtSerie.Text, txtCorrelativo.Text, Convert.ToInt32(txtIgv.Text),
                                dtDetalle);
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
                    else
                    {
                        MessageBox.Show("Primeramente el cliente tiene que pagar.", "Sistema de ventas - (Pagando)",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                if (this.txtIdArticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                    this.txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtIdArticulo, "Ingrese un valor");
                    errorIcono.SetError(txtCantidad, "Ingrese un valor");
                    errorIcono.SetError(txtDescuento, "Ingrese un valor");
                    errorIcono.SetError(txtPrecioVenta, "Ingrese un valor");
                }
                else
                {
                    bool registrar = true;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idDetalleIngreso"]) == Convert.ToInt32(this.txtIdArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el articulo en el detalle.");
                        }
                    }

                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        decimal subTotal = (Convert.ToInt32(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text)) - ((Convert.ToDecimal(this.txtDescuento.Text) / 100) * Convert.ToInt32(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text));
                        totalPagado += subTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");

                        //Agregar ese detalle al dtListadoDetalle

                        DataRow row = this.dtDetalle.NewRow();
                        row["idDetalleIngreso"] = Convert.ToInt32(this.txtIdArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precioVenta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }
                    else
                    {
                        MensajeError("No hay stock suficiente.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //Método para quitar.

        public void quitar()
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

        private void frmVenta_Load(object sender, EventArgs e)
        {
            //Evento Load del frmVenta.
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        //- . Inicio del código predeterminado . -

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Evento FormClosing del frmVenta.
            _instancia = null;
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento DoubleClick para transferir informacion.
            this.txtIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idVenta"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["cliente"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoComprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento CheckedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para asignar un CheckBox a cada fila del DGV.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones. -

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            //Evento Click del btnComprobante.
            frmReporteFactura frm = new frmReporteFactura();
            frm.IdVenta = Convert.ToInt32(this.dataListado.CurrentRow.Cells["idVenta"].Value);
            frm.ShowDialog();
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            this.BuscarFechas();
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarFilas();
        }

        private void pbBuscarCliente_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscarCliente.
            frmVistaCliente_Venta vista = new frmVistaCliente_Venta();
            vista.ShowDialog();
        }

        private void pbBuscarArticulo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscarArticulo.
            frmVistaArticulo_Venta vista = new frmVistaArticulo_Venta();
            vista.ShowDialog();
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbCancelar.
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbGuardar.
            this.guardar();
            this.lblPagoCon.Text = "0.0";
            this.lblCambio.Text = "0.0";
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbNuevo.
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbAgregar.
            this.agregar();
        }

        private void pbElimar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.quitar();
        }

        //- . Fin de los botones . -

        //- . Inicio del código obsoleto (Ignorar) . -

        private void txtSerie_TextChanged(object sender, EventArgs e) {/*Click por error*/}
    }
}
