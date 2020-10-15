using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private int _IdCliente;
        private string _Apellidos;
        private string _Nombres;
        private string _Sexo;
        private DateTime _FechaNac;
        private string _Telefono;
        private string _Email;
        private string _Localidad;
        private string _Calle;
        private string _DNI;
        private DateTime _FechaAlta;
        private DateTime _FechaBaja;
        private string _EstadoPer;
        private string _Observaciones;

        private string _TextoBuscar;



        public int IdProfesional { get => _IdCliente; set => _IdCliente = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }

        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Localidad { get => _Localidad; set => _Localidad = value; }

        public string Calle { get => _Calle; set => _Calle = value; }

        public string DNI { get => _DNI; set => _DNI = value; }
        public DateTime FechaAlta { get => _FechaAlta; set => _FechaAlta = value; }
        public DateTime FechaBaja { get => _FechaBaja; set => _FechaBaja = value; }
        public string EstadoPer { get => _EstadoPer; set => _EstadoPer = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Constructores
        public CD_Clientes()
        {

        }

        /*public CD_Profesionales(int IdProfesional, string Nombres, string Apellidos, string DNI, string EstadoPer,
            string Telefono, DateTime FechaNac,string Observaciones)
        {
            this.IdProfesional = IdProfesional;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Apellidos = Apellidos;
            this.DNI = DNI;
            this.EstadoPer = EstadoPer;
            this.Telefono = Telefono;
            this.FechaNac = FechaNac;
            this.Observaciones = Observaciones;

        }*/

        // ==================================================
        //  Permite devolver todos los profeisonales activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();

        // =========================================
        // Permite listar los clientes de la BD 
        // con la opcion de incluye bajas
        // =========================================
        public DataTable DameClientes(bool incluyeBajas)
        {

            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_clientes";

            MySqlParameter pIncluyeBajas = new MySqlParameter();
            pIncluyeBajas.ParameterName = "@pIncluyeBajas";
            pIncluyeBajas.MySqlDbType = MySqlDbType.String;
            // pNombre.Size = 60;
            // pNombre.Value = Empleado.Nombre;
            comando.Parameters.Add(pIncluyeBajas);

            tabla.Clear();
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion

            conexion.CerrarConexion();
            return tabla;

        }
        // =========================================
        // Metodo insertar profesional 
        // =========================================
        /*public string Insertar(CD_Profesionales Profesional)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_empleado";

                MySqlParameter pNombre = new MySqlParameter();
                pNombre.ParameterName = "@pNombre";
                pNombre.MySqlDbType = MySqlDbType.VarChar;
                pNombre.Size = 60;
                pNombre.Value = Empleado.Nombre;
                comando.Parameters.Add(pNombre);

                // Console.WriteLine("pNombre es : " + pNombre.Value);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Empleado.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = Empleado.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 40;
                pDireccion.Value = Empleado.Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Empleado.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 40;
                pFechaNac.Value = Empleado.FechaNac;
                comando.Parameters.Add(pFechaNac);


                // Console.WriteLine("el comando es : " + comando.CommandText[0]);
                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                conexion.CerrarConexion();
            }
            return rpta;

        }*/
        // =========================================
        // Metodo ELIMINAR profesional (da de baja)
        // =========================================
        public string Eliminar(CD_Profesionales Profesional)
        {
            string rpta = "";
            try
            {


                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_eliminar_profesional";

                MySqlParameter pIdProfesional = new MySqlParameter();
                pIdProfesional.ParameterName = "@pIdProfesional";
                pIdProfesional.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdProfesional.Value = Profesional.IdProfesional;
                comando.Parameters.Add(pIdProfesional);

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            return rpta;
        }
        // =========================================
        // Edita un profesional
        // =========================================
        /*public string Editar(CD_Profesionales Profesional)
        {
            Console.WriteLine("Produco.IdProducto es 1 : " + Profesional.IdProfesional);
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_empleado";

                MySqlParameter pIdEmpleado = new MySqlParameter();
                pIdEmpleado.ParameterName = "@pIdEmpleado";
                pIdEmpleado.MySqlDbType = MySqlDbType.Int32;
                // pIdEmpleado.Size = 60;
                pIdEmpleado.Value = Empleado.IdEmpleado;
                comando.Parameters.Add(pIdEmpleado);

                MySqlParameter pNombre = new MySqlParameter();
                pNombre.ParameterName = "@pNombre";
                pNombre.MySqlDbType = MySqlDbType.VarChar;
                pNombre.Size = 60;
                pNombre.Value = Empleado.Nombre;
                comando.Parameters.Add(pNombre);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Empleado.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = Empleado.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pDireccion = new MySqlParameter();
                pDireccion.ParameterName = "@pDireccion";
                pDireccion.MySqlDbType = MySqlDbType.VarChar;
                pDireccion.Size = 60;
                pDireccion.Value = Empleado.Direccion;
                comando.Parameters.Add(pDireccion);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.VarChar;
                pTelefono.Size = 15;
                pTelefono.Value = Empleado.Telefono;
                comando.Parameters.Add(pTelefono);

                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.VarChar;
                pFechaNac.Size = 60;
                pFechaNac.Value = Empleado.FechaNac;
                comando.Parameters.Add(pFechaNac);



                // Console.WriteLine("comando.Executeexe() es : " + comando.ExecuteReader().ToString());

                //Console.WriteLine("comando.ExecuteScalar().ToString() es : " + comando.ExecuteScalar().ToString());

                //Ejecutamos nuestro comando

                rpta = comando.ExecuteScalar().ToString() == "Ok" ? "OK" : "No se edito el Registro";



            }
            catch (Exception ex)
            {

                rpta = ex.Message;
                Console.WriteLine("rpta es : " + rpta);
            }
            finally
            {
                //if (conexion. == ConnectionState.Open) 
                conexion.CerrarConexion();
            }
            comando.Parameters.Clear();
            return rpta;
        }*/
        // =========================================
        // Busca un solo profesional
        // =========================================
        /*public DataTable BuscarEmpleado(CD_Profesionales Profesional)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_empleado";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Empleado.TextoBuscar;
                comando.Parameters.Add(pTextoBuscar);

                leer = comando.ExecuteReader();
                tabla.Load(leer);
                Console.WriteLine("tabla en capa datos es : " + tabla);
                Console.WriteLine("leer en capa datos es : " + leer.ToString());
                comando.Parameters.Clear();
                conexion.CerrarConexion();

                // return tabla;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Entro en el catch y tabla es en capa datos" + tabla);
                Console.WriteLine("Entro en el catch y ex es en capa datos" + ex.Message);

                tabla = null;
            }
            return tabla;

        }*/
        // =========================================
        // Devuelve un solo profesional dado un ID
        // =========================================
        /*public DataTable DameProfesional(int IdProfesional)
        {
            Console.WriteLine("IdProfesional en capa datos es : " + IdProfesional);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_profesional";

            MySqlParameter pIdProfesional = new MySqlParameter();
            pIdProfesional.ParameterName = "@pIdProfesional";
            pIdProfesional.MySqlDbType = MySqlDbType.Int32;
            // pIdProducto.Size = 60;
            pIdProfesional.Value = IdProfesional;
            comando.Parameters.Add(pIdProfesional);

            leer = comando.ExecuteReader();
            tabla.Load(leer);
            Console.WriteLine("tabla en capa datos es : " + tabla);
            Console.WriteLine("leer en capa datos es : " + leer.ToString());
            comando.Parameters.Clear();
            conexion.CerrarConexion();

            return tabla;

        }

        */
    }
}
