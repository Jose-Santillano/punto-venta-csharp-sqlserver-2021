using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        //Variables globales.

        private int childFormNumber = 0;
        public string idTrabajador = "", apellidos = "", nombre = "", acceso = "";

        public frmPrincipal()
        {
            InitializeComponent();
        }

        //- * Inicio de los métodos * -

        //Método para controlar la gestión de usuario y dependiendo de su rol activar los módulos correspondientes.
        private void gestionUsuario()
        {
            //Controlar los accesos.

            if (this.acceso == "Administrador")
            {
                this.mnuAlmacen.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsIngresosRapidos.Enabled = true;
                this.tsVentasRapidas.Enabled = true;
            }
            else if (this.acceso == "Vendedor")
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsIngresosRapidos.Enabled = false;
                this.tsVentasRapidas.Enabled = true;
            }
            else if (this.acceso == "Almacenero")
            {
                this.mnuAlmacen.Enabled = true;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramientas.Enabled = true;
                this.tsIngresosRapidos.Enabled = true;
                this.tsVentasRapidas.Enabled = false;
            }
            else
            {
                this.mnuAlmacen.Enabled = false;
                this.mnuVentas.Enabled = false;
                this.mnuMantenimiento.Enabled = false;
                this.mnuConsultas.Enabled = false;
                this.mnuHerramientas.Enabled = false;
                this.tsIngresosRapidos.Enabled = false;
                this.tsVentasRapidas.Enabled = false;
            }
        }

        //- * Fin de los métodos * -

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //Evento Load del frmPrincipal.
            this.gestionUsuario();
        }
       
        //- * Inicio ToolStrip Rapido * -

        private void tsSalirRapido_Click(object sender, EventArgs e)
        {
            //Evento click del tsSalirRapido.
            if (MessageBox.Show("¿Estas seguro de que deseas abandonar la aplicación? Esto la cerrará por completo.", 
                "Abandonar aplicación - (Sistema de ventas)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tsCerrarSesionRapido_Click(object sender, EventArgs e)
        {
            //Evento click del tsCerrarSesionRapido.
            if (MessageBox.Show("¿Estas seguro de que deseas cerrar la sesión? Esto te regresará al Login.",
                "Cerrar sesión - (Sistema de ventas)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLogin frm = new frmLogin();
                this.Close();
                frm.Show();
            }
        }

        private void tsVentasRapidas_Click(object sender, EventArgs e)
        {
            //Evebti Click del tsVentasRapidas.
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.IdTrabajador = Convert.ToInt32(this.idTrabajador);
        }

        private void tsIngresosRapidos_Click(object sender, EventArgs e)
        {
            //Evento Click del tsIgresosRapidos.
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.idTrabajador = Convert.ToInt32(this.idTrabajador);
        }

        //- * Fin ToolStrip Rapido * -

        //- * Inicio Submenú Sistema * -

        private void tsSalir_Click(object sender, EventArgs e)
        {
            //Evento Click del pcSalirSesion. (pbSalirSesion)
            if (MessageBox.Show("¿Estas seguro de que deseas abandonar la aplicación? Esto la cerrará por completo.", 
                "Abandonar aplicación - (Sistema de ventas)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tsCerrarSesion_Click(object sender, EventArgs e)
        {
            //Evento click del tsCerrar.
            if (MessageBox.Show("¿Estas seguro de que deseas cerrar la sesión? Esto te regresará al Login.",
                "Cerrar sesión - (Sistema de ventas)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                frmLogin frm = new frmLogin();
                this.Close();
                frm.Show();
            }
        }

        //- * Fin Submenú Sistema * -

        //- * Inicio Submenú Ventas * -

        private void tsVender_Click(object sender, EventArgs e)
        {
            //Evento Click del tsVender.
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.IdTrabajador = Convert.ToInt32(this.idTrabajador);
        }

        //- * Fin Submenú Ventas * -

        //- * Inicio Submenú Almacén * -

        private void tsArticulos_Click(object sender, EventArgs e)
        {
            //Evento Click del tsArticulos.
            frmArticulo frm = frmArticulo.GetInstancia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tsCategorias_Click(object sender, EventArgs e)
        {
            //Evento Click del tsCategorias.
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tsPresentaciones_Click(object sender, EventArgs e)
        {
            //Evento Click del tsPresentaciones.
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tsIngresos_Click(object sender, EventArgs e)
        {
            //Evento Click del tsIngresos.
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
            frm.idTrabajador = Convert.ToInt32(this.idTrabajador);
        }

        //- * Fin Submenú Almacén * -

        //- * Inicio Submenú Mantenimiento * -

        private void tsClientes_Click(object sender, EventArgs e)
        {
            //Evento Click del tsClientes.
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tsProveedores_Click(object sender, EventArgs e)
        {
            //Evento Click del tsProveedores.
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        private void tsTrabajadores_Click(object sender, EventArgs e)
        {
            //Evento Click del tsTrabajadores.
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }

        //- * Fin Submenú Mantenimiento * -

        //- * Inicio eventos de la plantilla. (** De preferencia ignorar **) * -

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        //Fin eventos de la plantilla.
    }
}
