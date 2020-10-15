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

        //Método Insertar que llama al método Insertar de la clase DArticulo
        //de la CapaDatos
        public static string Insertar(string Apellidos,string Nombres, string Sexo,DateTime FechaNac,
            string Telefono, string Email,string Localidad,string Calle,string DNI,
            string Observaciones)
        {
            // Console.WriteLine("En insertar , nombre es " + nombre);

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
            Obj.FechaNac = FechaNac;

            return "ok"; //.Insertar(Obj);
        }
        
        public DataTable DameProfesionales(bool incluyeBajas)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameProfesionales(incluyeBajas);
            return tabla;
        }
        
        public static string Eliminar(int IdProfesional)
        {
            CD_Profesionales Obj = new CD_Profesionales();
            Obj.IdProfesional = IdProfesional;
            return Obj.Eliminar(Obj);
        }

        public DataTable MostrarProfesional(int IdProfesional)
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.DameProfesional(IdProfesional);
            Console.WriteLine("tabla TableName en capa negocio es : " + tabla.TableName);
            Console.WriteLine("tabla Rows en capa negocio es : " + tabla.Rows);
            return tabla;
        }

        public static string Editar(int IdProfesional,string Apellidos, string Nombres, string Sexo,DateTime FechaNac,
            string Telefono, string Email,string Localidad,string Calle,string DNI,string EstadoPer,string Observaciones)
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

            // Console.WriteLine("Produco.IdProducto es 3 : " + IdProducto);

            return Obj.Editar(Obj);
        }

        public DataTable BuscarEmpleado(string textobuscar)
        {
            Console.WriteLine("textobuscar en capa negocio es : " + textobuscar);
            CD_Profesionales Obj = new CD_Profesionales();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarProfesional(Obj);
        }

    }
}
