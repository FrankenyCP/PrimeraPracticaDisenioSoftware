// =============================================================================
//  CapaNegocio · Recordatorio.cs
//  MANDATO 4 · Tipo de mensaje agregado SIN modificar ninguna clase existente.
// =============================================================================

using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCIÓN REFINADA (nueva en el Mandato 4): recordatorio de pago con fecha límite.
    /// </summary>
    /// <remarks>
    /// Se agregó en un archivo nuevo, sin tocar <see cref="Mensaje"/>, las otras subclases
    /// ni ningún canal. Funciona de inmediato con los 4 canales.
    /// </remarks>
    public class Recordatorio : Mensaje
    {
        /// <summary>Fecha límite del pago que se recuerda.</summary>
        private readonly DateTime _fechaLimite;

        /// <summary>Crea el recordatorio con su fecha límite y el canal (el puente).</summary>
        public Recordatorio(ICanal canal, string destinatario, string contenido, DateTime fechaLimite)
            : base(canal, destinatario, contenido)
        {
            _fechaLimite = fechaLimite;
        }

        /// <summary>Arma el texto con la fecha límite y delega el envío en el canal.</summary>
        public override void Notificar()
        {
            // Formato propio del recordatorio: prefijo + contenido + fecha (dd/MM/yyyy).
            string texto = $"Recordatorio: {Contenido} Fecha limite: {_fechaLimite:dd/MM/yyyy}.";
            Canal.Enviar(Destinatario, texto);
        }
    }
}
