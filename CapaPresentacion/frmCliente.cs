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
    public partial class frmCliente : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCliente()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre,"Ingrese el nombre del cliente.");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese los apellidos del cliente.");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la direccion del cliente del cliente.");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el numero de documento del cliente.");
        }

        //- . Inicio de los métodos . -

        //Método para mostrar mensaje de confirmación.
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método para mostrar mensaje de error.
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para limpiar todos los controles del formulario.

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
        }

        //Método para habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIdcliente.ReadOnly = !valor;
        }

        //Método para habilitar los botones.
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

        //Método para ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método para mostrar.
        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarApellidos.
        private void BuscarApelidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarNum_Documento.
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para guardar.

        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty
                    || this.txtNum_Documento.Text == string.Empty || this.txtDireccion.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtApellidos, "Ingrese los apellidos");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese una direccion");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtFechaNac.Value, this.cbTipo_Documento.Text, this.txtNum_Documento.Text,
                            this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text);
                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(), this.cbSexo.Text, this.dtFechaNac.Value, this.cbTipo_Documento.Text,
                            this.txtNum_Documento.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text);
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

        //Método para eliminar.

        public void eliminarRegistro()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas eliminar los registros seleccionados?", "Sistema de Ventas - (Cliente)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se eliminó correctamente el registro.");
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

        //- .  Fin de los métodos . -

        private void frmCliente_Load(object sender, EventArgs e)
        {
            //Evento Load del frmCliente.
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        //- . Inicio de código de eventos . -

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento CheckedChanged.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para hacer que cada fila tenga un CheckBox.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento para mandar la información para editar.
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipoDocumento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        //- . Fin de código de eventos .-

        //- . Inicio de los botones . - 

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApelidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarRegistro();
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            //Evento Click del pbNuevo.
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbGuardar.
            this.guardar();
        }

        private void pbEditar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEditar.
            if (!this.txtIdcliente.Text.Equals(""))
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
            this.txtIdcliente.Text = string.Empty;
        }

        //- . Fin de los botones . - 

        //- .  Inicio de código inutilizable . - (Ignorar)
        private void groupBox1_Enter(object sender, EventArgs e) {/*Click por error*/}
    }
}
