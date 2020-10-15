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
    public partial class formNuevoEditarProfesional : Form
    {
        CN_Profesionales objetoCN = new CN_Profesionales();
        DataTable respuesta;
        // int parametroActual;
        bool bandera;
        bool IsNuevo = false;
        // bool IsEditar = false;

        private int IdProfesional;
        private string Apellidos;
        private string Nombres;
        private Boolean sexo;   // true = mujer
        public formNuevoEditarProfesional(int IdProfesional,bool IsNuevo)
        {
            InitializeComponent();
            if (IsNuevo)
            {
                this.lblVariable.Text = "Nuevo";
            }else
            {
                this.lblVariable.Text = "Editar";
            }
        }
        // =========================================
        // Boton de ACEPTAR
        // =========================================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtApellidos.Text == string.Empty || this.txtNombres.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos");
                }
                if (rbHombre.Checked)
                {
                    sexo = false;
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        MessageBox.Show("Entro en insertar");
                        rpta = CN_Profesionales.Insertar(this.txtApellidos.Text.Trim(), this.txtNombres.Text.Trim(), this.sexo,this.dtpFechaNac.Value,this.txtTelefono.Text.Trim(),
                            this.txtEmail.Text.Trim(),this.txtLocalidad.Text.Trim(),this.txtCalle.Text.Trim(),this.txtDNI.Text.Trim(),this.rtbObservaciones.Text.Trim(), this.tbEspecialidad.Text.Trim());
                    }
                    else
                    {
                        // rpta = CN_Profesionales.Editar(this.IdCliente, this.txtTransporte.Text.Trim(), this.txtTitular.Text.Trim(), this.txtTelefono.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                }
                MessageBox.Show("rpta es " + rpta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // =========================================
        // Mensajes de error
        // =========================================
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Act-Fis", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Act-Fis", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
