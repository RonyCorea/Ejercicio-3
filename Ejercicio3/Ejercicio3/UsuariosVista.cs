using Datos.PermitirAcceso;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class UsuariosVista : Form
    {
        public UsuariosVista()
        {
            InitializeComponent();
        }

        UsuarioPA usuarioPA = new UsuarioPA(); 
        private void UsuariosVista_Load(object sender, EventArgs e)
        {
            MessageBox.Show("El código de usuario y contraseña son correctos");
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuarioPA.ListarUsuarios();
        }
    }
}
