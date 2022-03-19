using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.AlmacenarEntidades;
using Datos.PermitirAcceso;

namespace Ejercicio3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            UsuarioPA usuarioPA = new UsuarioPA();
            Usuario usuario = new Usuario();

            usuario = usuarioPA.Login(UsuarioTextBox.Text, ClaveTextBox.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos incorrectos");
                return;
            }
            
            UsuariosVista UsuariosVista = new UsuariosVista();
            UsuariosVista.Show();
        }
    }   
}
