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
    public partial class frmCategoria : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public frmCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoría");
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
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
        }

        //Método para habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdcategoria.ReadOnly = !valor;
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
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para buscar.
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para eliminar categoria.

        public void eliminarCategoria()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas eliminar los registros seleccionados?",
                    "Sistema de ventas - (Categoría)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCategoria.Eliminar(Convert.ToInt32(Codigo));

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

        //Método para guardar.

        public void guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCategoria.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        rpta = NCategoria.Editar(Convert.ToInt32(this.txtIdcategoria.Text), this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim());
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

        //- . Fin de los métodos .- 

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            //Evento Load del FrmCategoria. (frmCategoria)
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Evento TextChanged del txtBuscar.
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            //Evento DoubleClick del dataListado.
            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCategoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento ChekedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = this.chkEliminar.Checked ? true : false;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Evento para poner un CheckBox llamado Eliminar en cada fila.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        //- .  Inicio de los botones . - 

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            this.BuscarNombre();
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarCategoria();
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
            if (!this.txtIdcategoria.Text.Equals(""))
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
        }

        //- .  Fin de los botones . -

        //- . Inicio de código obsoleto. (Ignorar)

        private void groupBox1_Enter(object sender, EventArgs e) {/*Click por error*/}
        private void txtIcategoria_TextChanged(object sender, EventArgs e) {/*Click por error*/}
        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {/*Click por error*/}
    }
}
