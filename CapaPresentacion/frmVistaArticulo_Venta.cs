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
    public partial class frmVistaArticulo_Venta : Form
    {
        public frmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        private void frmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
            //Evento Load del frmVistaArticulo_Venta.
            this.dataListado.Columns[0].Visible = false;
        }

        //- . Inicio de los métodos . -

        //Método para Ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método para BuscarNombre.
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarNombre.
        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = NVenta.MostrarArticulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //- . Fin de los métodos . -

        //- . Inicio del código predeterminado . -

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            decimal par3, par4;
            int par5;
            DateTime par6;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idDetalleIngreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precioCompra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precioVenta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stockActual"].Value);
            par6 = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fechaVencimiento"].Value);
            form.SetArticulo(par1, par2, par3, par4, par5, par6);
            this.Hide();
        }

        //- . Fin del código predeterminado . -

        //- . Inicio de los botones . -

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbBuscar.
            if (cbBuscar.Text.Equals("Código"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        //- . Fin de los botones . -
    }
}
