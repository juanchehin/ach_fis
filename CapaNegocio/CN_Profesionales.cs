using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Agregados
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Profesionales
    {
        private CD_Profesionales objetoCD = new CD_Profesionales();

        // =========================================
        // Crea un profesional con todos sus datos
        // =========================================
        public static string Insertar(string Apellidos,string Nombres, bool Sexo,DateTime FechaNac,
            string Telefono, string Email,string Localidad,string Calle,string DNI,
            string Observaciones,string Especialidad)
        {
            Console.WriteLine("En insertar , Nombres es " + Nombres);

            CD_Profesionales Obj = new CD_Profesionales();
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Sexo = Sexo;
            Obj.FechaNac = FechaNac;
            Obj.Telefono = Telefono;
            Obj.Email = Email;
            Obj.Localidad = Localidad;
            Obj.Calle = Calle;
            Obj.DNI = DNI;
            Obj.Observaciones = Observaciones;
            Obj.Especialidad = Especialidad;

            Console.WriteLine("Obj.Insertar(Obj) + " + Obj.Insertar(Obj));

            return Obj.Insertar(Obj);
        }
        // =========================================
        // Devuelve un profesional dado su ID
        // =========================================
        public DataTable DameProfesionales(bool incluyeBajas)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameProfesionales(incluyeBajas);
            return tabla;
        }
        // =========================================
        // Elimina un profesional dado su ID
        // =========================================
        public static string Eliminar(int IdProfesional)
        {
            CD_Profesionales Obj = new CD_Profesionales();
            Obj.IdProfesional = IdProfesional;
            return Obj.Eliminar(Obj);
        }
        // =========================================
        // Devuelve un profesional dado su ID
        // =========================================
        public DataTable MostrarProfesional(int IdProfesional)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameProfesional(IdProfesional);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }
        // =========================================
        // Edita un profesional con sus datos
        // =========================================
        public static string Editar(int IdProfesional,string Apellidos, string Nombres, bool Sexo,DateTime FechaNac,
            string Telefono, string Email,string Localidad,string Calle,string DNI,string EstadoPer,string Observaciones,
            string Especialidad)
        {
            // Console.WriteLine("Produco.IdProducto es 2 : " + IdProducto);
            CD_Profesionales Obj = new CD_Profesionales();
            Obj.IdProfesional = IdProfesional;
            Obj.Apellidos = Apellidos;
            Obj.Nombres = Nombres;
            Obj.Sexo = Sexo;
            Obj.FechaNac = FechaNac;
            Obj.Telefono = Telefono;
            Obj.Email = Email;
            Obj.Localidad = Localidad;
            Obj.Calle = Calle;
            Obj.DNI = DNI;
            Obj.EstadoPer = EstadoPer;
            Obj.Observaciones = Observaciones;
            Obj.Especialidad = Especialidad;

            // Console.WriteLine("Produco.IdProducto es 3 : " + IdProducto);

            return Obj.Editar(Obj);
        }
        // =========================================
        // Busca un empleado dada una cadena de texto
        // =========================================
        public DataTable BuscarEmpleado(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            CD_Profesionales Obj = new CD_Profesionales();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProfesional(Obj);
        }

    }
}
