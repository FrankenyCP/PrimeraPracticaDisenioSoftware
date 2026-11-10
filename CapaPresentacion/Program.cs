// Practica 4 de 17 - Patron BRIDGE - Banco Popular del Cibao
// Frankeny Antonio Castillo Paniagua - 2025-0794 - Diseno de Software (UCE)
// CAPA DE PRESENTACION: menu de consola que demuestra cada mandato.

using CapaDatos;

namespace CapaPresentacion
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                MostrarMenu();
                string? opcion = Console.ReadLine()?.Trim();
                if (opcion == "0") break;

                if (int.TryParse(opcion, out int numero))
                {
                    Console.Clear();
                    EjecutarMandato(numero);
                    Console.WriteLine();
                    Console.Write("Presione ENTER para volver al menu...");
                    Console.ReadLine();
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("  PRACTICA 4 - PATRON BRIDGE - Banco Popular del Cibao");
            Console.WriteLine("=================================================================");
            Console.WriteLine("  1. Mandato 1: Jerarquia de implementacion (canales)");
            Console.WriteLine("  2. Mandato 2: Abstraccion (Mensaje + subclases)");
            Console.WriteLine("  3. Mandato 3: [URGENTE] y texto legal sin que el canal lo sepa");
            Console.WriteLine("  4. Mandato 4: CanalPush + nuevos mensajes (4 x 4 combinaciones)");
            Console.WriteLine("  5. Mandato 5: Estructura del puente y verificacion");
            Console.WriteLine("  0. Salir");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("  Elija una opcion: ");
        }

        private static void EjecutarMandato(int numero)
        {
            switch (numero)
            {
                case 1: Mandato1(); break;
                default: Console.WriteLine("Mandato pendiente o no valido."); break;
            }
        }

        // MANDATO 1 - Jerarquia de implementacion: ICanal y sus canales concretos
        private static void Mandato1()
        {
            Encabezado(1, "Jerarquia de implementacion: ICanal y CanalCorreo, CanalSms, CanalWhatsApp");

            // La presentacion trabaja contra la interfaz ICanal.
            ICanal correo = new CanalCorreo();
            ICanal sms = new CanalSms();
            ICanal whatsApp = new CanalWhatsApp();

            Console.WriteLine("Cada canal recibe (destinatario, texto) y lo entrega a su manera:\n");
            correo.Enviar("frankeny.castillo@correo.com", "Su estado de cuenta de octubre esta disponible.");
            Console.WriteLine();
            sms.Enviar("809-555-0147", "Su estado de cuenta de octubre esta disponible.");
            Console.WriteLine();
            whatsApp.Enviar("+1 809-555-0147", "Su estado de cuenta de octubre esta disponible.");

            Console.WriteLine();
            Console.WriteLine("Prueba de la regla propia del SMS (maximo 160 caracteres):\n");
            sms.Enviar("809-555-0147",
                "Este es un texto muy largo para comprobar que el canal SMS recorta el contenido " +
                "cuando supera el limite de caracteres permitido por la red de telefonia movil del pais.");
        }

        private static void Encabezado(int numero, string titulo)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine($"  MANDATO {numero}");
            Console.WriteLine($"  {titulo}");
            Console.WriteLine("=================================================================");
            Console.WriteLine();
        }
    }
}