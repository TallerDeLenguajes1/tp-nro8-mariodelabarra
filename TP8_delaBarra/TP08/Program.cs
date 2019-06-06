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
    public enum EstadoCivil { Solterx =1, Casadx, Viudx};

    class Program
    {
        
        static void Main(string[] args)
        {
            List<Empleado> empleadoLista = new List<Empleado>();
            Empleado empleado;
            int opc = 0;
            string busqueda;
            string[] delimitador;

            //|========== Creando el empleado para Lista ==========|

            //for (int i = 0; i < 20; i++)
            //{
            //    empleado = crearEmpleado();
            //    Console.WriteLine("\n|====== Empleado n. {0} =======|", i + 1);
            //    Empleado.mostrarEmpleado(empleado);
            //    empleadoLista.Add(empleado);
            //    Console.ReadKey();
            //}
            //|============ Menu para buscar empleados en Lista=======|
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

            //============Cargando empleados a un archivo .csv=============
            string rutaCSV, fecha;
            rutaCSV = "NuevosEmpleados.csv";
            //crearArchivo(rutaCSV);//Creo el archivo para escribir los empleados

            //if (File.Exists(rutaCSV))
            //{
            //    for (int i = 0; i < 3; i++)
            //    {
            //        empleado = crearEmpleado();
            //        Console.WriteLine("\n|====== Empleado n. {0} =======|", i+1);
            //        Empleado.mostrarEmpleado(empleado);
            //        escribirArchivo(rutaCSV, empleado);//Envio el empleado para escribirlo en el archivo
            //        Console.ReadKey();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("El archivo csv no existe.");
            //}

            backUpEmpleados(rutaCSV);

            Console.ReadKey();

        }

        private static Empleado crearEmpleado()
        {
            string Nombre, Apellido;
            string[] nombres = { "Pablo", "Esteban", "Tyrion", "Will", "Jon"};
            string[] apellidos = { "Quito", "Tormout", "Taly", "White", "Snow"};
            Genero genero;
            Cargo cargo;
            EstadoCivil estadoCivil;
            int sueldo, cantHijos;
            DateTime fechaIngreso, fechaNac;
            Empleado cargaEmpleado;
            Random rnd = new Random();

            Nombre = nombres[rnd.Next(5)]; //Nombre

            Apellido = apellidos[rnd.Next(5)]; // Apellido
            
            fechaNac = new DateTime(rnd.Next(1950, 1990), rnd.Next(1, 12), rnd.Next(1, 28)); //Fecha de nacimiento

            estadoCivil = (EstadoCivil) rnd.Next(1, 3); //Estado Civil

            genero =(Genero) rnd.Next(1, 2); //Genero
            
            sueldo = rnd.Next(8000, 50000); //Sueldo
            
            cantHijos = rnd.Next(0, 6); //cant de hijos
            cargo = (Cargo)rnd.Next(1, 5); //Cargando el cargo del empleado
            
            fechaIngreso = new DateTime(rnd.Next(1980, 2018), rnd.Next(1, 12), rnd.Next(1, 28)); //Inicializo la fecha de ingreso

            cargaEmpleado = new Empleado(Nombre, Apellido, fechaNac, estadoCivil, cantHijos, genero, sueldo, cargo, fechaIngreso);

            return cargaEmpleado;
        }

        public static Empleado empleadoArchivo(string[] cadenaEmpleado)//Carga un empleado desde el archivo csv
        {
            Empleado empleadoAux;
            string nombre, apellido;
            Genero genero;
            Cargo cargo;
            EstadoCivil estadoCivil;
            int sueldo, cantHijos, anio, mes, dia;
            DateTime fechaIngreso, fechaNac;
            string[] fecha;

            nombre = cadenaEmpleado[0];
            apellido = cadenaEmpleado[1];

            //======= Fecha de Nacimiento ===========
            fecha = cadenaEmpleado[2].Split('/');
            anio = int.Parse(fecha[2]);
            mes = int.Parse(fecha[1]);
            dia = int.Parse(fecha[0]);
            fechaNac = new DateTime(anio, mes, dia);

            //========= Estado Civil ===========
            if (cadenaEmpleado[3] == "Soltero" || cadenaEmpleado[3] == "Soltera"){
                estadoCivil = (EstadoCivil)1; /*Soltero/a*/
            }else if (cadenaEmpleado[3] == "Casada" || cadenaEmpleado[3] == "Casado")
            {
                estadoCivil = (EstadoCivil)2;/*Casado/a*/
            }else {
                estadoCivil = (EstadoCivil)3; //Viudo/
            }
            
            // ======== Genero ==========
            if (cadenaEmpleado[4] == "Masculino") genero =(Genero) 1; else genero = (Genero) 2;

            //========= Sueldo ==============
            sueldo = int.Parse(cadenaEmpleado[5]);

            //========== Cantidad de Hijos =======
            cantHijos = int.Parse(cadenaEmpleado[6]);

            //========== Cargo ============
            if(cadenaEmpleado[7] == "Auxiliar")
            {
                cargo = (Cargo)1;
            }else if(cadenaEmpleado[7] == "Administrativo")
            {
                cargo = (Cargo)2;
            }else if(cadenaEmpleado[7] == "Ingeniero")
            {
                cargo = (Cargo)3;
            }else if(cadenaEmpleado[7] == "Especialista")
            {
                cargo = (Cargo)4;
            }else
            {
                cargo = (Cargo)5;
            }

            //========= Fecha de Ingreso ============
            fecha = cadenaEmpleado[8].Split('/');
            anio = int.Parse(fecha[2]);
            mes = int.Parse(fecha[1]);
            dia = int.Parse(fecha[0]);
            fechaIngreso = new DateTime(anio, mes, dia);

            //======== Instanciando empleado =============
            empleadoAux = new Empleado(nombre, apellido, fechaNac, estadoCivil, cantHijos, genero, sueldo, cargo, fechaIngreso);

            return empleadoAux;
        }

        public static void crearArchivo(string rutaCSV)
        {
            using(StreamWriter archivo = File.AppendText(rutaCSV))
            {
                archivo.Write("Nombre;Apellido;Fecha de Nacimiento;EstadoCivil;Genero;Sueldo;Cantidad de hijos;Cargo;Fecha de Ingreso\n");
                archivo.Close();
            }
        }

        public static void escribirArchivo(string rutaCSV, Empleado empleadoAux)
        {
            string fecha;
            using(StreamWriter file = new StreamWriter(rutaCSV, true))
            {
                file.Write(empleadoAux.Nombre + ";");
                file.Write(empleadoAux.Apellido + ";");
                fecha = Convert.ToDateTime(empleadoAux.fechaNac).ToString("dd/MM/yy");
                file.Write(fecha + ";");
                file.Write(empleadoAux.estadoCivil + ";");
                file.Write(empleadoAux.genero + ";");
                file.Write(empleadoAux.sueldo + ";");
                file.Write(empleadoAux.cantHijos + ";");
                file.Write(empleadoAux.cargo + ";");
                fecha = Convert.ToDateTime(empleadoAux.fechaIngreso).ToString("dd/MM/yy");
                file.Write(fecha + "\n");
                file.Close();
            }
        }

        public static void backUpEmpleados(string rutaCSV)
        {
            string[] directorio = System.IO.Directory.GetLogicalDrives();//Obtiene los discos disponibles que hay en la PC
            string destino;
            int opc = 0;

            Console.WriteLine("¿En que unidad desea hacer la copia de seguridad?:\n1- {0}\n2- {1}\n", directorio[0], directorio[4]);
            opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1: destino = @"C:\BackUp"; break;
                default: destino = @"H:\BackUp"; break;
            }

            if (!Directory.Exists(destino)){
                Directory.CreateDirectory(destino);
            }
                
            if(!File.Exists(destino+@"\NuevosEmpleados.bk"))
            {
                File.Copy(rutaCSV, destino + @"\NuevosEmpleados.bk");
            }else
            {
                Console.WriteLine("Ya existe una copia del archivo en el directorio: {0}", destino);
            }
        
        }
    }
}