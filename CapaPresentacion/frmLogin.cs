using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Librerías añadidas.
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        //Código para darle un border-radius al Form.
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
       (
           int nLeftRect,     // x-coordinate of upper-left corner
           int nTopRect,      // y-coordinate of upper-left corner
           int nRightRect,    // x-coordinate of lower-right corner
           int nBottomRect,   // y-coordinate of lower-right corner
           int nWidthEllipse, // height of ellipse
           int nHeightEllipse // width of ellipse
       );

        public frmLogin()
        {
            InitializeComponent();

            //Asignamos su borde-radius.
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 30, 30));
        }

        //Inicio de los métodos.

        public void iniciarSesion()
        {
            try
            {
                //Creamos el DataTable y mandamos los datos.
                DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtUsuario.Text, this.txtPassword.Text);

                //Verificamos si existe el usuario.
                if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("Lamentablemente no tienes acceso al sistema, verifica tus credenciales o contacta a soporte técnico.",
                        "Usuario no encontrado - (Sistema de ventas)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Abrimos el formulario y le mandamos sus datos.
                    frmPrincipal frm = new frmPrincipal();

                    //Enviamos los valores a sus respectivas variables.
                    frm.idTrabajador = Datos.Rows[0][0].ToString();
                    frm.apellidos = Datos.Rows[0][1].ToString();
                    frm.nombre = Datos.Rows[0][2].ToString();
                    frm.acceso = Datos.Rows[0][3].ToString();

                    //Mensaje de inicio éxitoso.
                    MessageBox.Show("Inicio de sesión válido, bienvenido al Sistema de ventas " + Datos.Rows[0][2].ToString() + " " +
                        Datos.Rows[0][1].ToString() + ".", "Usuario encontrado - (Sistema de ventas)", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frm.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Ha ocuriddo un problema con la base de datos, por favor contacta a soporte técnico.",
                        "Error inesperado - (Sistema de ventas)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fin de los métodos.

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //Evento Load del frmLogin.
            this.lblHora.Text = DateTime.Now.ToString();
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            //Evento Tick del timerHora.

            //Actualizamos la hora cada segundo.
            this.lblHora.Text = DateTime.Now.ToString();
        }
       
        private void pbIniciarSesion_Click(object sender, EventArgs e)
        {
            //Evento Click del pbIniciarSesion.
            this.iniciarSesion();
        }

        private void pcSalirSesion_Click(object sender, EventArgs e)
        {
            //Evento Click del pcSalirSesion. (pbSalirSesion)
            if(MessageBox.Show("¿Estas seguro de que deseas abandonar la aplicación?", "Abandonar aplicación - (Sistema de ventas)", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
