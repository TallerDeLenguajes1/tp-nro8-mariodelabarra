using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{
    public enum Cargo { Auxiliar = 1, Administrativo, Ingeniero, Especialista, Investigador };
    public enum Genero { Masculino = 1, Femenino };

    class Program
    {
        
        static void Main(string[] args)
        {
            List<Empleado> empleadoLista = new List<Empleado>();
            Empleado empleado;
            int opc = 0;
            string busqueda, rutaCSV;
            string[] archivoCSV, cadenaEmpl;
            string[] delimitador;

            rutaCSV = "NuevosEmpleados.csv";
            archivoCSV = File.ReadAllLines(rutaCSV);

            cadenaEmpl = archivoCSV[0].Split(';');//tamaño 0-8

            empleado = empleadoArchivo(cadenaEmpl);


            //|========== Creando el empleado ==========|

            //for (int i = 0; i < 20; i++)
            //{
            //    empleado = crearEmpleado();
            //    Console.WriteLine("\n|====== Empleado n. {0} =======|", i+1);
            //    Empleado.mostrarEmpleado(empleado);
            //    empleadoLista.Add(empleado);
            //    Console.ReadKey();
            //}

            //do
            //{
            //    Console.WriteLine("\n|===== Buscador de empleados =====|");
            //    Console.WriteLine("\nIngrese el nombre del empleado que desea buscar: ");
            //    busqueda = Console.ReadLine();
            //    delimitador = busqueda.Split(' ');

            //    Empleado.busquedaEmpleado(empleadoLista, delimitador);
            //    Console.WriteLine("\n¿Desea continuar con la busqueda?: (1- Si ; 0- No)");
            //    opc = int.Parse(Console.ReadLine());
            //} while (opc != 0);


            Console.ReadKey();

        }

        private static Empleado crearEmpleado()
        {
            string Nombre, Apellido;
            string[] nombres = { "Pablo", "Esteban", "Tyrion", "Will", "Jon"};
            string[] apellidos = { "Quito", "Tormout", "Taly", "White", "Snow"};
            Genero genero;
            Cargo cargo;
            int estadoCivil, sueldo, cantHijos;
            DateTime fechaIngreso, fechaNac;
            Empleado cargaEmpleado;
            Random rnd = new Random();

            Nombre = nombres[rnd.Next(5)]; //Nombre

            Apellido = apellidos[rnd.Next(5)]; // Apellido
            
            fechaNac = new DateTime(rnd.Next(1950, 1990), rnd.Next(1, 12), rnd.Next(1, 28)); //Fecha de nacimiento

            estadoCivil = rnd.Next(1, 2); //Estado Civil

            genero =(Genero) rnd.Next(1, 2); //Genero
            
            sueldo = rnd.Next(8000, 50000); //Sueldo
            
            cantHijos = rnd.Next(0, 10); //cant de hijos
            cargo = (Cargo)rnd.Next(1, 5); //Cargando el cargo del empleado
            
            fechaIngreso = new DateTime(rnd.Next(1980, 2018), rnd.Next(1, 12), rnd.Next(1, 28)); //Inicializo la fecha de ingreso

            cargaEmpleado = new Empleado(Nombre, Apellido, fechaNac, estadoCivil, cantHijos, genero, sueldo, cargo, fechaIngreso);

            return cargaEmpleado;
        }

        public static Empleado empleadoArchivo(string[] cadenaEmpleado)
        {
            Empleado empleadoAux;

        }
    }
}