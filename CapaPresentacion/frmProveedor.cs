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
    public partial class frmProveedor : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese la razon social del Proveedor.");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el numero de documento del Proveedor.");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la direccion del Proveedor.");
        }

        //- . Inicio de los métodos . -

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
            this.txtRazon_Social.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
        }

        //Método para Habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdproveedor.ReadOnly = !valor;
        }

        //Método para Habilitar los botones.
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.pbNuevo.Enabled = false;
                this.pbGuardar.Enabled = true;
                this.pbEditar.Enabled = false;
                this.pbCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.pbNuevo.Enabled = true;
                this.pbGuardar.Enabled = false;
                this.pbEditar.Enabled = true;
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
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarRazon_Social.
        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarNum_Documento.
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para guardar.
        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNum_Documento.Text == string.Empty || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Nombre");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese una direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(), this.cbSector_Comercial.Text,
                            this.cbTipo_Documento.Text, this.txtNum_Documento.Text, this.txtDireccion.Text, this.txtTelefono.Text,
                            this.txtEmail.Text, this.txtUrl.Text);
                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtIdproveedor.Text), this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text, this.cbTipo_Documento.Text, this.txtNum_Documento.Text, this.txtDireccion.Text,
                            this.txtTelefono.Text, this.txtEmail.Text, this.txtUrl.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro.");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro.");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
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
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se elimin+o correctamente el registro.");
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

        //- . Fin de los métodos . -

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        //- . Inicio del código predeterminado . -

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento CheckedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para asignar un CheckBox en cada fila del DGV.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento DoubleClick para transferir la información.
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idProveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razonSocial"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sectorComercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoDocumento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones . -

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbNuevo.
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbGuardar.
            this.guardar();
        }

        private void pbEditar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEditar.
            if (!this.txtIdproveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero el registro a modificar.");
            }
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbCancelar.
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIdproveedor.Text = string.Empty;
        }

        private void pbBuscar_Click_1(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarRegistros();
        }

        //- . Fin de los botones . -

        //- . Inicio del código obsoleto (Ignorar) . -

        private void tabPage1_Click(object sender, EventArgs e){/*Click por error*/}
    }
}
