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
    public partial class frmArticulo : Form
    {
        //Variables globales.
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static frmArticulo _Instancia;

        public frmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del articulo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del articulo.");
            this.ttMensaje.SetToolTip(this.cbIdpresentacion, "Seleccione la presentacion del articulo.");
            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
        }

        //- . Inicio de los métodos . - 

        //Método para obtener la instancia del formulario.
        public static frmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new frmArticulo();
            }
            return _Instancia;
        }

        //Método para asignar la categoría.
        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            MessageBox.Show(nombre);
            this.txtCategoria.Text = nombre;
        }

        //Método para mostrar mensaje de confirmación.
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método para mostrar mensaje de error.
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método para limpiar todos los controles del formulario.
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //Método para habilitar los controles del formulario.
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.pbBuscarCliente.Enabled = valor;
            this.cbIdpresentacion.Enabled = valor;
            this.pbAgregar.Enabled = valor;
            this.pbLimpiar.Enabled = valor;
            this.txtIdarticulo.ReadOnly = !valor;
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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Método para mostrar los datos en el DGV.
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para buscar.
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para llenar combobox.
        private void LlenarComboPresentacion()
        {
            cbIdpresentacion.DataSource = NPresentacion.Mostrar();
            cbIdpresentacion.ValueMember = "idPresentacion";
            cbIdpresentacion.DisplayMember = "nombre";

        }

        //Método para guardar el artículo.
        public void guardarArticulo()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtIdcategoria.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados.");
                    errorIcono.SetError(txtNombre, "Ingrese un valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un valor");
                    errorIcono.SetError(txtCategoria, "Ingrese un valor");
                }
                else
                {
                    //Almacenamos en el buffer lo insertado en el picturebox.

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim(),
                            imagen, Convert.ToInt32(this.txtIdcategoria.Text), Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text), this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdcategoria.Text),
                            Convert.ToInt32(this.cbIdpresentacion.SelectedValue));
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

        //Método para eliminar artículos.

        public void eliminarArticulos()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas eliminar los registros seleccionados?", 
                    "Sistema de Ventas - (Artículos)", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            //Evento Load del frmArticulo.
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //Evento TextChanged del txtBuscar.
            this.BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Forma para poner un CheckBox en cada fila del DGV.
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Forma para pasar todos los datos de la fila seleecionada para poder editarlos.
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idArticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idCategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            this.cbIdpresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idPresentacion"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            //Evento ChekedChanged del chkEliminar.
            this.dataListado.Columns[0].Visible = chkEliminar.Checked ? true : false;
        }

        //- . Inicio de los botones de mantenimiento . -

        private void pbBuscarCliente_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscarCliente.
            frmVistaCategoria_Articulo form = new frmVistaCategoria_Articulo();
            form.ShowDialog();
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
            this.guardarArticulo();
        }

        private void pbEditar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEditar.
            if (!this.txtIdarticulo.Text.Equals(""))
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

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbAgregar.
            OpenFileDialog dialog = new OpenFileDialog();

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void pbLimpiar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbLimpiar.
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            this.BuscarNombre();
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbEliminar.
            this.eliminarArticulos();
        }

        //- . Fin de los botones de mantenimiento. -
    }
}
