using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Profesionales
    {
        private int _IdProfesional;
        private string _Apellidos;
        private string _Nombres;
        private string _Sexo;
        private DateTime _FechaNac;
        private string _Telefono;
        private string _Email;
        private string _Localidad;
        private string _Calle;
        private string _DNI;
        private string _EstadoPer;
        private string _Observaciones;

        private string _TextoBuscar;



        public int IdProfesional { get => _IdProfesional; set => _IdProfesional = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }

        public string Nombres { get => _Nombres; set => _Nombres = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNac { get => _FechaNac; set => _FechaNac = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Localidad { get => _Localidad; set => _Localidad = value; }

        public string Calle { get => _Calle; set => _Calle = value; }

        public string DNI { get => _DNI; set => _DNI = value; }
        public string EstadoPer { get => _EstadoPer; set => _EstadoPer = value; }
        public string Observaciones { get => _Observaciones; set => _Observaciones = value; }

        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        //Constructores
        public CD_Profesionales()
        {

        }

        public CD_Profesionales(int IdProfesional, string Nombres, string Apellidos, string DNI, string EstadoPer,
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

        }

        // ==================================================
        //  Permite devolver todos los profeisonales activos de la BD
        // ==================================================
        private CD_Conexion conexion = new CD_Conexion();

        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();


        public DataTable DameProfesionales(bool incluyeBajas)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "bsp_dame_profesionales";

            MySqlParameter pIncluyeBajas = new MySqlParameter();
            pIncluyeBajas.ParameterName = "@pIncluyeBajas";
            pIncluyeBajas.MySqlDbType = MySqlDbType.VarChar;
            // pNombre.Size = 60;
            pIncluyeBajas.Value = incluyeBajas;
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
        public string Insertar(CD_Profesionales Profesional)
        {
            string rpta = "";
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_alta_profesional";
                // Console.WriteLine("pNombre es : " + pNombre.Value);

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Profesional.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Profesional.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.VarChar;
                pSexo.Size = 1;
                pSexo.Value = Profesional.Sexo;
                comando.Parameters.Add(pSexo);


                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.Date;
                // pFechaNac.Size = 40;
                pFechaNac.Value = Profesional.FechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.Int32;
                pTelefono.Size = 11;
                pTelefono.Value = Profesional.Telefono;
                comando.Parameters.Add(pTelefono);


                MySqlParameter pEmail = new MySqlParameter();
                pEmail.ParameterName = "@pEmail";
                pEmail.MySqlDbType = MySqlDbType.VarChar;
                pEmail.Size = 60;
                pEmail.Value = Profesional.Email;
                comando.Parameters.Add(pEmail);

                MySqlParameter pLocalidad = new MySqlParameter();
                pLocalidad.ParameterName = "@pLocalidad";
                pLocalidad.MySqlDbType = MySqlDbType.VarChar;
                pLocalidad.Size = 70;
                pLocalidad.Value = Profesional.Localidad;
                comando.Parameters.Add(pLocalidad);

                MySqlParameter pCalle = new MySqlParameter();
                pCalle.ParameterName = "@pCalle";
                pCalle.MySqlDbType = MySqlDbType.VarChar;
                pCalle.Size = 60;
                pCalle.Value = Profesional.Calle;
                comando.Parameters.Add(pCalle);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = Profesional.DNI;
                comando.Parameters.Add(pDNI);

                /*MySqlParameter pEstadoPer = new MySqlParameter();
                pEstadoPer.ParameterName = "@pEstadoPer";
                pEstadoPer.MySqlDbType = MySqlDbType.VarChar;
                pEstadoPer.Size = 1;
                pEstadoPer.Value = Profesional.EstadoPer;
                comando.Parameters.Add(pEstadoPer);*/

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Profesional.Observaciones;
                comando.Parameters.Add(pObservaciones);



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

        }
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
        public string Editar(CD_Profesionales Profesional)
        {
            Console.WriteLine("Produco.IdProducto es 1 : " + Profesional.IdProfesional);
            string rpta = "";
            comando.Parameters.Clear();// si no ponerlo al comienzo de esta funcion
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_editar_empleado";

                MySqlParameter pApellidos = new MySqlParameter();
                pApellidos.ParameterName = "@pApellidos";
                pApellidos.MySqlDbType = MySqlDbType.VarChar;
                pApellidos.Size = 60;
                pApellidos.Value = Profesional.Apellidos;
                comando.Parameters.Add(pApellidos);

                MySqlParameter pNombres = new MySqlParameter();
                pNombres.ParameterName = "@pNombres";
                pNombres.MySqlDbType = MySqlDbType.VarChar;
                pNombres.Size = 60;
                pNombres.Value = Profesional.Nombres;
                comando.Parameters.Add(pNombres);

                MySqlParameter pSexo = new MySqlParameter();
                pSexo.ParameterName = "@pSexo";
                pSexo.MySqlDbType = MySqlDbType.VarChar;
                pSexo.Size = 1;
                pSexo.Value = Profesional.Sexo;
                comando.Parameters.Add(pSexo);


                MySqlParameter pFechaNac = new MySqlParameter();
                pFechaNac.ParameterName = "@pFechaNac";
                pFechaNac.MySqlDbType = MySqlDbType.Date;
                // pFechaNac.Size = 40;
                pFechaNac.Value = Profesional.FechaNac;
                comando.Parameters.Add(pFechaNac);

                MySqlParameter pTelefono = new MySqlParameter();
                pTelefono.ParameterName = "@pTelefono";
                pTelefono.MySqlDbType = MySqlDbType.Int32;
                pTelefono.Size = 11;
                pTelefono.Value = Profesional.Telefono;
                comando.Parameters.Add(pTelefono);


                MySqlParameter pEmail = new MySqlParameter();
                pEmail.ParameterName = "@pEmail";
                pEmail.MySqlDbType = MySqlDbType.VarChar;
                pEmail.Size = 60;
                pEmail.Value = Profesional.Email;
                comando.Parameters.Add(pEmail);

                MySqlParameter pLocalidad = new MySqlParameter();
                pLocalidad.ParameterName = "@pLocalidad";
                pLocalidad.MySqlDbType = MySqlDbType.VarChar;
                pLocalidad.Size = 70;
                pLocalidad.Value = Profesional.Localidad;
                comando.Parameters.Add(pLocalidad);

                MySqlParameter pCalle = new MySqlParameter();
                pCalle.ParameterName = "@pCalle";
                pCalle.MySqlDbType = MySqlDbType.VarChar;
                pCalle.Size = 60;
                pCalle.Value = Profesional.Calle;
                comando.Parameters.Add(pCalle);

                MySqlParameter pDNI = new MySqlParameter();
                pDNI.ParameterName = "@pDNI";
                pDNI.MySqlDbType = MySqlDbType.VarChar;
                pDNI.Size = 45;
                pDNI.Value = Profesional.DNI;
                comando.Parameters.Add(pDNI);

                MySqlParameter pEstadoPer = new MySqlParameter();
                pEstadoPer.ParameterName = "@pEstadoPer";
                pEstadoPer.MySqlDbType = MySqlDbType.VarChar;
                pEstadoPer.Size = 1;
                pEstadoPer.Value = Profesional.EstadoPer;
                comando.Parameters.Add(pEstadoPer);

                MySqlParameter pObservaciones = new MySqlParameter();
                pObservaciones.ParameterName = "@pObservaciones";
                pObservaciones.MySqlDbType = MySqlDbType.VarChar;
                pObservaciones.Size = 255;
                pObservaciones.Value = Profesional.Observaciones;
                comando.Parameters.Add(pObservaciones);


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
        }
        // =========================================
        // Busca un solo profesional
        // =========================================
        public DataTable BuscarProfesional(CD_Profesionales Profesional)
        {
            try
            {
                comando.Connection = conexion.AbrirConexion();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = "bsp_buscar_profesional";

                MySqlParameter pTextoBuscar = new MySqlParameter();
                pTextoBuscar.ParameterName = "@pTextoBuscar";
                pTextoBuscar.MySqlDbType = MySqlDbType.VarChar;
                pTextoBuscar.Size = 30;
                pTextoBuscar.Value = Profesional.TextoBuscar;
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

        }
        // =========================================
        // Devuelve un solo profesional dado un ID
        // =========================================
        public DataTable DameProfesional(int IdProfesional)
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
    }
}
