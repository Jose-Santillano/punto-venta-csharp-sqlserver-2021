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
    public partial class frmVistaProveedorIngreso : Form
    {
        public frmVistaProveedorIngreso()
        {
            InitializeComponent();
        }

        private void frmVistaProveedorIngreso_Load(object sender, EventArgs e)
        {
            //Evento Load del frmVistaProveedorIngreso.
            this.Mostrar();
        }

        //- .  Inicio de los métodos . -

        //Método para ocultar columnas.
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método para mostrar.
        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
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

        //- . Fin de los métodos . -

        //- . Inicio del código predeterminado . -

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idProveedor"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["razonSocial"].Value);
            frm.setProveedor(par1, par2);
            this.Hide();
        }

        //- . Fin del código predeterminado . -

        private void pbBuscar_Click(object sender, EventArgs e)
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

        //- . Fin de los botones . -
    }
}
