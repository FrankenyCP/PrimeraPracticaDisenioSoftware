// Practica 4 de 17 - Patron BRIDGE - Banco Popular del Cibao
// Frankeny Antonio Castillo Paniagua - 2025-0794 - Diseno de Software (UCE)
// CAPA DE PRESENTACION: menu de consola que demuestra cada mandato.

using CapaDatos;
using CapaNegocio;

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
                case 2: Mandato2(); break;
                case 3: Mandato3(); break;
                case 4: Mandato4(); break;
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
            correo.Enviar("frankenycastillo@correo.com", "Su estado de cuenta de octubre esta disponible.");
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

        // MANDATO 2 - Abstraccion: Mensaje recibe un ICanal y declara Notificar()
        private static void Mandato2()
        {
            Encabezado(2, "Abstraccion: Mensaje(ICanal) declara Notificar(); subclases AlertaSeguridad y Promocion");

            // El canal se inyecta por el constructor: aqui se construye el puente.
            Mensaje alerta = new AlertaSeguridad(new CanalSms(), "809-555-0147",
                "Se detecto un inicio de sesion desde un dispositivo nuevo.");

            Mensaje promocion = new Promocion(new CanalCorreo(), "frankeny.castillo@correo.com",
                "Tasa especial de 9.5% en prestamos de vehiculo este mes.");

            Console.WriteLine($"-> AlertaSeguridad conectada al canal {alerta.NombreCanal}:");
            alerta.Notificar();
            Console.WriteLine();

            Console.WriteLine($"-> Promocion conectada al canal {promocion.NombreCanal}:");
            promocion.Notificar();
            Console.WriteLine();

            // Ventaja del puente: el canal se cambia en tiempo de ejecucion.
            alerta.CambiarCanal(new CanalWhatsApp());
            Console.WriteLine($"-> La misma alerta, ahora conectada al canal {alerta.NombreCanal} (cambio en ejecucion):");
            alerta.Notificar();
        }

        // MANDATO 3 - Cada tipo de mensaje arma su texto; el canal no lo sabe
        private static void Mandato3()
        {
            Encabezado(3, "La alerta agrega [URGENTE] y la promocion agrega el texto legal, sin que el canal lo sepa");

            const string textoAlerta = "Se bloqueo su tarjeta terminada en 4417 por 3 intentos fallidos.";
            const string textoPromo = "Cero comision en remesas recibidas hasta el 30/11.";

            ICanal[] canales = { new CanalCorreo(), new CanalSms(), new CanalWhatsApp() };

            Console.WriteLine($"Contenido base de la alerta:    \"{textoAlerta}\"");
            Console.WriteLine($"Contenido base de la promocion: \"{textoPromo}\"\n");

            Console.WriteLine("--- AlertaSeguridad por los 3 canales (el prefijo lo pone el MENSAJE) ---\n");
            foreach (ICanal canal in canales)
            {
                new AlertaSeguridad(canal, "Frankeny Castillo", textoAlerta).Notificar();
                Console.WriteLine();
            }

            Console.WriteLine("--- Promocion por los 3 canales (el texto legal lo pone el MENSAJE) ---\n");
            foreach (ICanal canal in canales)
            {
                new Promocion(canal, "Frankeny Castillo", textoPromo).Notificar();
                Console.WriteLine();
            }

            Console.WriteLine("Conclusion: ICanal.Enviar(destinatario, texto) solo recibe texto ya armado.");
            Console.WriteLine("Ningun canal contiene la palabra [URGENTE] ni el texto legal en su codigo.");
        }

        // MANDATO 4 - Extender ambas jerarquias sin tocar clases existentes
        private static void Mandato4()
        {
            Encabezado(4, "Nuevo canal CanalPush y nuevos mensajes Recordatorio y Confirmacion: 4 x 4");

            const string cliente = "Frankeny Castillo";

            // Implementacion: 4 canales (CanalPush es nuevo).
            ICanal[] canales = { new CanalCorreo(), new CanalSms(), new CanalWhatsApp(), new CanalPush() };

            // Abstraccion: 4 tipos de mensaje (Recordatorio y Confirmacion son nuevos).
            // Cada entrada sabe crear su mensaje sobre CUALQUIER canal que se le pase.
            var fabricasDeMensajes = new List<(string Tipo, Func<ICanal, Mensaje> Crear)>
            {
                ("AlertaSeguridad", c => new AlertaSeguridad(c, cliente,
                    "Retiro de RD$ 25,000 en cajero de Higuey. Si no fue usted, llame al banco.")),
                ("Promocion", c => new Promocion(c, cliente,
                    "Certificado financiero al 11% anual a 12 meses.")),
                ("Recordatorio", c => new Recordatorio(c, cliente,
                    "El pago minimo de su tarjeta es RD$ 3,450.", new DateTime(2026, 11, 25))),
                ("Confirmacion", c => new Confirmacion(c, cliente,
                    "Transferencia de RD$ 8,000 a la cuenta ***2290 realizada.", "TR-104582")),
            };

            int combinacion = 0;
            foreach (var (tipo, crear) in fabricasDeMensajes)
            {
                foreach (ICanal canal in canales)
                {
                    combinacion++;
                    Console.WriteLine($"#{combinacion,2}  {tipo} + {canal.GetType().Name}");
                    crear(canal).Notificar();
                    Console.WriteLine();
                }
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($" Combinaciones demostradas: {combinacion} (4 mensajes x 4 canales)");
            Console.WriteLine(" Clases concretas con Bridge: 4 mensajes + 4 canales = 8");
            Console.WriteLine(" Con herencia harian falta:   4 tipos x 4 canales  = 16 clases combinadas");
            Console.WriteLine(" Clases existentes modificadas: 0");
            Console.WriteLine("   (solo se AGREGARON CanalPush.cs, Recordatorio.cs y Confirmacion.cs)");
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