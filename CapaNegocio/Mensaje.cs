using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCION del patron Bridge: "que" se envia (el tipo de mensaje).
    /// En lugar de heredar de un canal, guarda una referencia a ICanal:
    /// esa referencia es el PUENTE entre las dos jerarquias (composicion).
    /// </summary>
    public abstract class Mensaje
    {
        /// <summary>El puente: el canal concreto llega por el constructor.</summary>
        protected ICanal Canal { get; private set; }

        /// <summary>A quien va dirigido el mensaje.</summary>
        public string Destinatario { get; }

        /// <summary>Contenido base del mensaje.</summary>
        public string Contenido { get; }

        protected Mensaje(ICanal canal, string destinatario, string contenido)
        {
            Canal = canal ?? throw new ArgumentNullException(nameof(canal));
            Destinatario = destinatario;
            Contenido = contenido;
        }

        /// <summary>Cada tipo de mensaje decide como notificar usando su canal.</summary>
        public abstract void Notificar();

        /// <summary>Permite cambiar el canal en tiempo de ejecucion.</summary>
        public void CambiarCanal(ICanal nuevoCanal)
        {
            Canal = nuevoCanal ?? throw new ArgumentNullException(nameof(nuevoCanal));
        }

        /// <summary>Nombre del canal actual (para mostrarlo en consola).</summary>
        public string NombreCanal => Canal.Nombre;
    }
}