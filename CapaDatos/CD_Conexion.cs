using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_Conexion
    {
        MySqlConnection Con = new MySqlConnection("datasource = localhost;username = root;password = '';SslMode = none;database='ach_gym'");
        public CD_Conexion()
        {
            AbrirConexion();
        }
        public MySqlConnection AbrirConexion()
        {
            // string ConnectString = "datasource = localhost;username = root;password =;database=gomerialeon";
            // ConectionString => "datasource =localhost;username = root;password =;database=gomerialeon"
            try
            {
                Con.Open();
                //MessageBox.Show("Estas conectado!");
                return Con;
            }
            catch(Exception e)
            {
                //MessageBox.Show("Error Act Fis : " + e.Message);
                return Con;
            }
        }

        public MySqlConnection CerrarConexion()
        {
            // string ConnectString = "datasource = localhost;username = root;password =;database=gomerialeon";
            // MySqlConnection Con = new MySqlConnection("datasource = localhost;username = root;password =;database=gomerialeon");
            try
            {
                Con.Close();
                 // MessageBox.Show("Conexion cerrada!");
                return Con;
            }
            catch (Exception e)
            {
                // MessageBox.Show("Error Act Fis : " + e.Message);
                return Con;
            }
        }
    }

}
