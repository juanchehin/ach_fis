using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Agregados
using CapaNegocio;
// using System.DateTime;

namespace CapaPresentacion
{
    public partial class formClientes : Form
    {
        CN_Clientes objetoCN = new CN_Clientes();

        private int idCliente;
        private bool IsNuevo = false;
        // private bool IsEditar = false;
        public formClientes()
        {
            InitializeComponent();
        }
        private void DameClientes()
        {
            dataListadoClientes.DataSource = objetoCN.DameClientes(this.cbIncluyeBajas.Checked);
            // Oculto el IdEmpleado. Lo puedo seguir usando como parametro de eliminacion
            dataListadoClientes.Columns[0].Visible = false;
            lblTotalClientes.Text = "Total de Registros: " + Convert.ToString(dataListadoClientes.Rows.Count);

            // dataListadoEmpleados.Columns[0].ReadOnly = true;
        }
        //Limpiar todos los controles del formulario

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Act Fis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Act Fis", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dataListadoProfesionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("e.ColumnIndex " + e.ColumnIndex);    // Dice que columna se hizo click
            if (e.ColumnIndex == dataListadoClientes.Columns["Marcar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListadoClientes.Rows[e.RowIndex].Cells["Marcar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarProfesional();
        }

        private void BuscarProfesional()
        {
            /*Console.WriteLine("this.txtBuscar.Text es " + this.txtBuscar.Text);
            this.dataListadoProfesionales.DataSource = objetoCN.BuscarEmpleado(this.txtBuscar.Text);
            // this.OcultarColumnas();
            lblTotalProfesionales.Text = "Total de Registros: " + Convert.ToString(dataListadoProfesionales.Rows.Count);*/
        }

        private void btnNuevoProfesional_Click(object sender, EventArgs e)
        {
            /*Console.WriteLine("this.IdEmpleado en click nuevo es  : " + this.IdEmpleado);
            formNuevoEditarEmpleado frm = new formNuevoEditarEmpleado(this.IdEmpleado, true);
            frm.MdiParent = this.MdiParent;
            frm.Show();*/
            // this.Close();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            /*try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar al profesional", "Gimnasio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    Console.WriteLine("El IdProfesional en eliminar es " + this.idProfesional);
                    CN_Empleados.Eliminar(this.idProfesional);
                    this.DameProfesionales();
                    this.MensajeOk("Se elimino de forma correcta el registro");
                }
                txtBuscar.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }*/
        }

        private void dataListadoProfesionales_SelectionChanged(object sender, EventArgs e)
        {
            if (dataListadoClientes.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataListadoClientes.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataListadoClientes.Rows[selectedrowindex];
                this.idCliente = Convert.ToInt32(selectedRow.Cells["IdCliente"].Value);
            }
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(this, new EventArgs());
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.DameClientes();
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            DameClientes();
        }
    }

}
