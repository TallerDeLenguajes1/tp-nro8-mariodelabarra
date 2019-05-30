using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP08
{

    class Empleado
    {
        public string Nombre, Apellido;
        public Genero genero;
        public Cargo cargo;
        public int estadoCivil, sueldo, cantHijos;
        public DateTime fechaIngreso, fechaNac;

        public Empleado(string _Nombre, string _Apellido, DateTime _fechaNac, int _estadoCivil, int _cantHijos, Genero _genero, int _sueldo, Cargo _cargo, DateTime _fechaIngreso)
        {
            Nombre = _Nombre;
            Apellido = _Apellido;
            fechaNac = _fechaNac;
            estadoCivil = _estadoCivil;
            cantHijos = _cantHijos;
            genero = _genero;
            sueldo = _sueldo;
            cargo = _cargo;
            fechaIngreso = _fechaIngreso;

        }

        //Calculo de edad

        public static int edadEmpleado(Empleado empleado)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = 0;
            if (empleado.fechaNac.Month < fechaActual.Month)
            {
                edad = fechaActual.Year - empleado.fechaNac.Year;
            }
            else if (empleado.fechaNac.Month == fechaActual.Month)
            {
                if (empleado.fechaNac.Day <= fechaActual.Day)
                {
                    edad = fechaActual.Year - empleado.fechaNac.Year;
                }
                else
                {
                    edad = fechaActual.Year - empleado.fechaNac.Year - 1;
                }
            }
            else
            {
                edad = fechaActual.Year - empleado.fechaNac.Year - 1;
            }
            return edad;
        }

        //Calculo de Antiguedad
        public static double antiguedad(Empleado empleado)
        {
            DateTime fechaActual = DateTime.Now;
            double antiguedadEmp;

            antiguedadEmp = (fechaActual.Year - empleado.fechaIngreso.Year);

            return antiguedadEmp;
        }

        //Calculo de jubilacion

        public static int calculoJubilacion(Empleado empleado)
        {
            DateTime fechaActual = DateTime.Now;
            int edadAct = edadEmpleado(empleado);
            if (empleado.genero == Genero.Femenino)
            {
                if (edadAct >= 60) return 0; else return 60 - edadAct;
            }
            else
            {
                if (edadAct >= 65) return 0; else return 65 - edadAct;
            }
        }

        //Calculo del Salario
        public static double salario(Empleado empleado)
        {
            double Salario, Adicional, antiguedad;
            antiguedad = (Empleado.antiguedad(empleado)) / 10;

            if (antiguedad < 20)
            {
                Adicional = empleado.sueldo * (0.2 * antiguedad);
            }
            else
            {
                Adicional = (empleado.sueldo * 0.25) * antiguedad;
            }
            if (empleado.cargo == Cargo.Ingeniero || empleado.cargo == Cargo.Especialista)
            {
                Adicional = Adicional + (Adicional * 0.50);
            }
            if (empleado.estadoCivil == 1 && empleado.cantHijos > 2) Adicional = Adicional + 5000;

            Salario = empleado.sueldo + Adicional;

            return Salario;
        }

        public static void mostrarEmpleado(Empleado empleado)
        {
            Console.WriteLine("Nombre y apellido: {0} {1}", empleado.Nombre, empleado.Apellido);
            Console.WriteLine("Fecha de nacimiento: {0}", empleado.fechaNac.ToShortDateString());
            Console.WriteLine("Estado Civil: {0}", empleado.estadoCivil);
            Console.WriteLine("Genero: {0}", empleado.genero);
            Console.WriteLine("Sueldo: {0}", empleado.sueldo);
            Console.WriteLine("Cargo: {0}", empleado.cargo);
            Console.WriteLine("Fecha de ingreso: {0}", empleado.fechaIngreso.ToShortDateString());
        }
        public static void busquedaEmpleado(List<Empleado> empleadoLista, string[] delimitador)
        {
            int indice = empleadoLista.FindIndex(x => x.Nombre.Contains(delimitador[0]) && x.Apellido.Contains(delimitador[1]));
            try
            {
                Empleado.mostrarEmpleado(empleadoLista[indice]);
                Console.WriteLine("\nEmpleado n. {0}\n", indice + 1);
                Console.WriteLine("La edad del empleado es de: {0}", edadEmpleado(empleadoLista[indice]));
                Console.WriteLine("El empleado tiene {0} años de antiguedad.", Empleado.antiguedad(empleadoLista[indice]));
                Console.WriteLine("Al empleado le faltan {0} años para jubilarse.\n", calculoJubilacion(empleadoLista[indice]));

            }catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("El empleado {0}, {1} no existe en la base de datos.", delimitador[0], delimitador[1]);
            }
            
        }
    }
}
