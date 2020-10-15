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
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formProfesionales frm = new formProfesionales();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void formPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
