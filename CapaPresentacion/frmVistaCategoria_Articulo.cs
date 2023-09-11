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
    public partial class frmVistaCategoria_Articulo : Form
    {
        public frmVistaCategoria_Articulo()
        {
            InitializeComponent();
        }

        private void frmVistaCategoria_Articulo_Load(object sender, EventArgs e)
        {
            //Evento Load del frmVistaCategoria_Articulo.
            this.Mostrar();
        }

        //- . Inicio de los métodos . -

        //Método para ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método para Mostrar.
        private void Mostrar()
        {
            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para Buscar.
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //- . Fin de los métodos . -
       
        //- . Inicio del código predeterminado . -

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmArticulo form = frmArticulo.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idCategoria"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCategoria(par1, par2);
            this.Hide();
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones . -

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            this.BuscarNombre();
        }

        //- . Fin de los botones . -

        //- . Inicio de código obsoleto (Ignorar) . -

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e){/*Click por error*/}
    }
}
