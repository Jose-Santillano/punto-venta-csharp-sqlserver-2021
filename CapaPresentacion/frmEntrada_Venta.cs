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
    public partial class frmEntrada_Venta : Form
    {
        public frmEntrada_Venta()
        {
            InitializeComponent();
        }

        private void pbCancelar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbCancelar.
            if(MessageBox.Show("¿Estas seguro de que deseas cancelar la transacción de dinero?", "Sistema de ventas - (Cancelando venta)",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pbGuardar_Click(object sender, EventArgs e)
        {
            //Evento Click del pbGuardar.
            if (!this.txtPagoCon.Equals(""))
            {
                frmVenta form = frmVenta.GetInstancia();
                decimal par1;
                par1 = Convert.ToDecimal(this.txtPagoCon.Text);
                form.SetPagoCon(par1);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Porfavor ingrese la cantidad con la que el cliente esta pagando.", "Sistema de ventas - (Pagando)",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEntrada_Venta_Load(object sender, EventArgs e)
        {
            //Evento Load frmEntrada.
        }
    }
}
