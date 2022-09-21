using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola
{
    class Program
    {
        //vamos a declarar e inicializar un objeto tipo RepositorioPaciente
        //que sera un campo propio de la clase Program
        private static IRepositorioPaciente _repoPaciente = new RepositorioPaciente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            System.Console.WriteLine("Hola Github");
            bool control = true;

            while (control)
            {
                System.Console.WriteLine();
                Console.WriteLine("Bienvenido al programa hospital en casa G44");
                System.Console.WriteLine("#### Menu Principal ####");
                System.Console.WriteLine("1. Adicionar Paciente");
                System.Console.WriteLine("2. Borrar Paciente");
                System.Console.WriteLine("3. Buscar Paciente");
                System.Console.WriteLine("4. Asignar Medico");
                System.Console.WriteLine("5. Salir");
                System.Console.WriteLine("Dígite su opción");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AdicionarPaciente();
                        break;
                    case 2:
                        System.Console.WriteLine("Bienvenido a la opcion de eliminar paciente");
                        System.Console.WriteLine("Dígite el id del paciente a eliminar");
                        int idEliminar = Convert.ToInt32(Console.ReadLine());
                        EliminarPaciente(idEliminar);
                        break;
                    case 3:
                        System.Console.WriteLine("Bienvenido a la opcion de buscar paciente");
                        System.Console.WriteLine("Dígite el id del paciente a buscar");
                        int idBuscar = Convert.ToInt32(Console.ReadLine());
                        BuscarPaciente(idBuscar);
                        break;
                    case 4:
                        break;
                    case 5:
                        System.Console.WriteLine("Gracias por usar nuestro programa");
                        control = false;
                        break;
                    default:
                        System.Console.WriteLine("Opción invalida, dígite nuevamente");
                        break;

                }
            }
        }
        //metodo para realizar el CRUD con la base de datos
        //metodo para adicionar paciente de la base de datos
        private static void AdicionarPaciente()
        {
            var paciente = new Paciente 
            {
                Nombre = "Pepito",
                Apellido = "Ochoa",
                NumeroTelefono = "3123687865",
                Genero = Genero.Masculino,
                Direccion = "Calle Cangrejo",
                Longitud = 12.00F,
                Latitud = 6.12F,
                Ciudad = "New York",
                FechaNacimiento = new DateTime (2000,02,14)
            };

            Console.WriteLine($"El paciente {paciente.Nombre} {paciente.Apellido} será ingresado a la BD");
            _repoPaciente.AddPaciente(paciente);
            System.Console.WriteLine();
            System.Console.WriteLine($"El paciente {paciente.Nombre} {paciente.Apellido} será ingresado a la BD");
        }
        //metodo para eliminar paciente de la base de datos
        private static void EliminarPaciente(int idPaciente)
        {
            System.Console.WriteLine("¿Estas seguro de eliminar el paciente? \n1.  SI  \n2.  NO");
            string opcion = Console.ReadLine();
            if (opcion == "1")
            {
                System.Console.WriteLine($"El paciente con id {idPaciente} será eliminado");
                _repoPaciente.DeletePaciente(idPaciente);
                System.Console.WriteLine("Paciente eliminado con éxito");
            }
        }
        
        //metodo para buscar paciente de la base de datos
        private static void BuscarPaciente (int idPaciente)
        {
            var paciente = _repoPaciente.GetPaciente(idPaciente);
            System.Console.WriteLine($"El paciente con id No {idPaciente} es {paciente.Nombre} {paciente.Apellido}");
            System.Console.WriteLine($"Su información es: ");
            System.Console.WriteLine($"Telefono: {paciente.NumeroTelefono}");
            System.Console.WriteLine($"Dirección: {paciente.Direccion}");
        }
    }
}
