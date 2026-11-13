// =============================================================================
//  CapaNegocio · Confirmacion.cs
//  MANDATO 4 · Cuarto tipo de mensaje para completar la matriz 4 x 4.
// =============================================================================

using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCIÓN REFINADA (nueva en el Mandato 4): confirmación de una transacción.
    /// </summary>
    /// <remarks>
    /// Junto con AlertaSeguridad, Promocion y Recordatorio completa los 4 tipos de mensaje
    /// que pide la matriz "4 mensajes x 4 canales". Se agregó sin modificar clases existentes.
    /// </remarks>
    public class Confirmacion : Mensaje
    {
        /// <summary>Número de referencia de la transacción confirmada.</summary>
        private readonly string _numeroReferencia;

        /// <summary>Crea la confirmación con su referencia y el canal (el puente).</summary>
        public Confirmacion(ICanal canal, string destinatario, string contenido, string numeroReferencia)
            : base(canal, destinatario, contenido)
        {
            _numeroReferencia = numeroReferencia;
        }

        /// <summary>Arma el texto con el número de referencia y delega el envío en el canal.</summary>
        public override void Notificar()
        {
            string texto = $"Confirmacion: {Contenido} Ref. {_numeroReferencia}.";
            Canal.Enviar(Destinatario, texto);
        }
    }
}
