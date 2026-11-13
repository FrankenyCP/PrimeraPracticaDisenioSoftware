// =============================================================================
//  CapaDatos · CanalPush.cs
//  MANDATO 4 · Canal agregado SIN modificar ninguna clase existente.
// =============================================================================

namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR CONCRETO (nuevo en el Mandato 4): notificación push en la app del banco.
    /// </summary>
    /// <remarks>
    /// Se agregó en un archivo nuevo: no se tocó <see cref="ICanal"/>, ni los otros
    /// canales, ni ninguna clase de CapaNegocio. Aun así funciona con los 4 tipos de
    /// mensaje, porque todos hablan con la interfaz y no con canales concretos.
    /// </remarks>
    public class CanalPush : ICanal
    {
        /// <summary>Aplicación móvil que muestra la notificación.</summary>
        private const string App = "App BPCibao";

        /// <summary>Nombre del canal que se muestra al usuario.</summary>
        public string Nombre => "Push";

        /// <summary>
        /// Muestra la notificación push en el dispositivo del cliente.
        /// </summary>
        public void Enviar(string destinatario, string texto)
        {
            // Origen propio del canal: la app del banco -> dispositivo del cliente.
            Console.WriteLine($"  [PUSH]     {App}  ->  dispositivo de {destinatario}");
            Console.WriteLine($"             {texto}");
        }
    }
}
