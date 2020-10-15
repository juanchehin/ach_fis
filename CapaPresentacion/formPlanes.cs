using CapaNegocio;
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
    public partial class formPlanes : Form
    {
        CN_Planes objetoCN = new CN_Planes();
        public formPlanes()
        {
            InitializeComponent();
        }
        private void damePlanes()
        {
            dataListadoPlanes.DataSource = objetoCN.DamePlanes(this.cbIncluyeBajas.Checked);
            // Oculto el IdEmpleado. Lo puedo seguir usando como parametro de eliminacion
            dataListadoPlanes.Columns[0].Visible = false;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoPlanes.Rows.Count);
        }
        private void formPlanes_Load(object sender, EventArgs e)
        {
            this.damePlanes();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.damePlanes();
        }
    }
}
