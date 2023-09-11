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
    public partial class frmTrabajador : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del trabajador");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese el apellidos del trabajador");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese el usuario para que el trabajador ingrese al sistema");
            this.ttMensaje.SetToolTip(this.txtPassword, "Ingrese el password para que el trabajador ingrese al sistema");
            this.ttMensaje.SetToolTip(this.cbAcceso, "Seleccione el nivel de acceso del trabajador");
        }

        //- . Inicio de los métodos . -

        //Métodos para mostrar mensaje de confirmación.
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Métodos para mostrar mensaje de error.
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Métodos para limpiar todos los controles del formulario.

        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtIdtrabajador.Text = string.Empty;
        }

        //Métodos para habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.cbAcceso.Enabled = valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
            this.txtIdtrabajador.ReadOnly = !valor;
        }

        //Métodos para habilitar los botones.
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

        //Métodos para ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Métodos para mostrar.
        private void Mostrar()
        {
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Métodos para BuscarApellidos.
        private void BuscarApelidos()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Métodos para BuscarNum_Documento.
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para guardar.

        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty
                    || this.txtNum_Documento.Text == string.Empty || this.txtDireccion.Text == string.Empty || this.txtUsuario.Text == string.Empty
                    || this.txtPassword.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                    errorIcono.SetError(txtApellidos, "Ingrese los apellidos");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un numero de documento");
                    errorIcono.SetError(txtDireccion, "Ingrese una direccion");
                    errorIcono.SetError(txtUsuario, "Ingrese un usuario");
                    errorIcono.SetError(txtPassword, "Ingrese un password");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtFechaNac.Value, this.txtNum_Documento.Text,
                            this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text);
                    }
                    else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtIdtrabajador.Text), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(), this.cbSexo.Text, this.dtFechaNac.Value,
                            this.txtNum_Documento.Text, this.txtDireccion.Text, this.txtTelefono.Text, this.txtEmail.Text, cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text);
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
                Opcion = MessageBox.Show("¿Realmente deseas eliminar los registros seleccionados?", 
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
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));

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

        //- . Fin de los métodos . -

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            //Evento Load del frmTrabajador.
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        //- . Inicio del código predeterminado . -

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento ChekedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para que aparezca un CheckBox en cada fila del DGV.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento DoubleClik del dataListado para transferir la informacion.
            this.txtIdtrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idTrabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaNacimiento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numDocumento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acceso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones . -

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
            else if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApelidos();
            }
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click pbEliminar.
            this.eliminarRegistros();
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
            if (!this.txtIdtrabajador.Text.Equals(""))
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
            this.Limpiar();
            this.Habilitar(false);
            this.txtIdtrabajador.Text = string.Empty;
        }

        //- . Fin de los botones . -
    }
}
