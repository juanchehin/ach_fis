using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Planes
    {
        private int _IdPlan;
        private string _Plan;
        private decimal _Precio;
        private string _Descripcion;
        private string _EstadoPlan;
        private string _HorarioInicio;
        private string _HorarioFin;
        private int _CantClases;

        private string _TextoBuscar;



        public int IdPlan { get => _IdPlan; set => _IdPlan = value; }
        public string Plan { get => _Plan; set => _Plan = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string EstadoPlan { get => _EstadoPlan; set => _EstadoPlan = value; }
        public string HorarioInicio { get => _HorarioInicio; set => _HorarioInicio = value; }
        public string HorarioFin { get => _HorarioFin; set => _HorarioFin = value; }
        public int CantClases { get => _CantClases; set => _CantClases = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Constructores
        public CD_Planes()
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
        // Permite listar los planes de la BD 
        // con la opcion de incluye bajas
        // =========================================
        public DataTable DamePlanes(bool incluyeBajas)
        {
            Console.WriteLine("pIncluyeBajas es antes : " + incluyeBajas);
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_planes";

            MySqlParameter pIncluyeBajas = new MySqlParameter();
            pIncluyeBajas.ParameterName = "@pIncluyeBajas";
            pIncluyeBajas.MySqlDbType = MySqlDbType.Int32;
            // pNombre.Size = 60;
            pIncluyeBajas.Value = incluyeBajas;
            // Console.WriteLine("pIncluyeBajas es : " + pIncluyeBajas.Value);
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
