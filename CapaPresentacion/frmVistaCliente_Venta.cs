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
    public partial class frmVistaCliente_Venta : Form
    {
        public frmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        private void frmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            //Evento Load del frmVistaCliente_Venta.
            this.Mostrar();
            this.dataListado.Columns[0].Visible = false;
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
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarApellidos.
        private void BuscarApelidos()
        {
            this.dataListado.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método para BuscarNum_Documento.
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //- . Fin de los métodos . -

        //- . Inicio del código predeterminado . -

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idCliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value) + ' ' + Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.SetCliente(par1, par2);
            this.Hide();
        }

        //- . Fin del código predeterminado . -

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

        //- . Fin de los botones . -
    }
}
