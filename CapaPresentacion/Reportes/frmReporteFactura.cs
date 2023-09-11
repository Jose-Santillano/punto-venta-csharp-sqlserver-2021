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
    public partial class frmReporteFactura : Form
    {
        private int _IdVenta;

        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }

        public frmReporteFactura()
        {
            InitializeComponent();
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_fecha' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spreporte_fechaTableAdapter.Fill(this.dsPrincipal.spreporte_fecha, IdVenta);

                this.reportViewer1.RefreshReport();
            }
#pragma warning disable CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' se ha declarado pero nunca se usa
            {
                this.reportViewer1.RefreshReport();
            }
            
            
        }
    }
}
