using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleadoLista = new List<Empleado>();
            Empleado empleado = new Empleado();
            Random rnd = new Random();
            int opc = 0;
            string busqueda;
            string[] delimitador;

            //Creando el empleado
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("|====Empleado n. {0}====|", i + 1);
                empleado = crearEmpleado(ref empleado, rnd);
                empleadoLista.Add(empleado);
            }

            do
            {
                Console.WriteLine("\n|===== Buscador de empleados =====|");
                Console.WriteLine("\nIngrese el nombre del empleado que desea buscar: ");
                busqueda = Console.ReadLine();
                delimitador = busqueda.Split(' ');

                Empleado.busquedaEmpleado(empleadoLista, delimitador);
                Console.WriteLine("\n¿Desea continuar con la busqueda?: (1- Si ; 0- No)");
                opc = int.Parse(Console.ReadLine());
            } while (opc != 0);


            Console.ReadKey();
        }

        private static Empleado crearEmpleado(ref Empleado empleado, Random rnd)
        {
           
            int varAux;
            DateTime fechaIngreso;
            //Nombre y apellido
            Console.WriteLine("Ingrese el nombre del empleado: ");
            empleado.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el apellido del empleado: ");
            empleado.Apellido = Console.ReadLine();
            //Fecha de nacimiento
            empleado.fechaNac = new DateTime(rnd.Next(1950, 1990), rnd.Next(1, 12), rnd.Next(1, 28));
            //Estado civil, genero, sueldo, cargo
            varAux = rnd.Next(1, 2);
            empleado.estadoCivil = varAux;
            Console.WriteLine("Ingrese el genero del empleado: (1- Masculino; 2- Femenino)");
            varAux = int.Parse(Console.ReadLine());
            if (varAux == 1) empleado.genero = Genero.Masculino; else empleado.genero = Genero.Femenino;
            Console.WriteLine("Ingrese el sueldo del empleado: ");
            varAux = int.Parse(Console.ReadLine());
            empleado.sueldo = varAux;
            //cant de hijos
            varAux = rnd.Next(0, 10);
            empleado.cantHijos = varAux;

            //Cargando el cargo del empleado
            varAux = rnd.Next(1, 5);
            switch (varAux)
            {
                case 1: empleado.cargo = Cargo.Auxiliar; break;
                case 2: empleado.cargo = Cargo.Administrativo; break;
                case 3: empleado.cargo = Cargo.Ingeniero; break;
                case 4: empleado.cargo = Cargo.Especialista; break;
                case 5: empleado.cargo = Cargo.Investigador; break;
            }

            //Inicializo la fecha de ingreso
            fechaIngreso = new DateTime(rnd.Next(1980, 2018), rnd.Next(1, 12), rnd.Next(1, 28));
            //================================
            empleado.fechaIngreso = fechaIngreso;


            return empleado;
        }
    }
}
