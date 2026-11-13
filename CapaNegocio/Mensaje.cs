// =============================================================================
//  CapaNegocio · Mensaje.cs
//  MANDATO 2 · Clase abstracta que recibe un ICanal y declara Notificar().
// =============================================================================

using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCIÓN del patrón Bridge: representa "qué" se envía (el tipo de mensaje).
    /// </summary>
    /// <remarks>
    /// En lugar de heredar de un canal (lo que obligaría a crear AlertaSms, PromocionCorreo,
    /// etc.), el mensaje GUARDA una referencia a <see cref="ICanal"/>. Esa referencia es el
    /// PUENTE entre las dos jerarquías y se arma por composición, no por herencia.
    /// Resultado: las clases crecen por suma (tipos + canales) y no por multiplicación.
    /// </remarks>
    public abstract class Mensaje
    {
        /// <summary>
        /// EL PUENTE: canal concreto por el que saldrá el mensaje.
        /// Es <c>protected</c> para que solo las subclases lo usen, y su tipo es la
        /// interfaz, así que puede ser cualquier canal (correo, SMS, WhatsApp, push...).
        /// </summary>
        protected ICanal Canal { get; private set; }

        /// <summary>A quién va dirigido el mensaje.</summary>
        public string Destinatario { get; }

        /// <summary>Contenido base del mensaje, antes de que cada tipo lo complete.</summary>
        public string Contenido { get; }

        /// <summary>
        /// Construye el mensaje recibiendo el canal desde afuera (inyección por constructor).
        /// </summary>
        /// <param name="canal">Implementación por la que se enviará. No puede ser null.</param>
        /// <param name="destinatario">Quién recibe el mensaje.</param>
        /// <param name="contenido">Texto base del mensaje.</param>
        protected Mensaje(ICanal canal, string destinatario, string contenido)
        {
            // Se valida que exista un canal: sin él no hay puente.
            Canal = canal ?? throw new ArgumentNullException(nameof(canal));
            Destinatario = destinatario;
            Contenido = contenido;
        }

        /// <summary>
        /// Método abstracto: cada tipo de mensaje decide cómo arma su texto
        /// y luego delega la entrega en su <see cref="Canal"/>.
        /// </summary>
        public abstract void Notificar();

        /// <summary>
        /// Cambia el canal en tiempo de ejecución. Ventaja del Bridge: el mismo mensaje
        /// puede salir por otro canal sin crear ninguna clase nueva.
        /// </summary>
        public void CambiarCanal(ICanal nuevoCanal)
        {
            Canal = nuevoCanal ?? throw new ArgumentNullException(nameof(nuevoCanal));
        }

        /// <summary>Nombre del canal actual (solo para mostrarlo en consola).</summary>
        public string NombreCanal => Canal.Nombre;
    }
}
