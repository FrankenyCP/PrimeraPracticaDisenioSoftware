// =============================================================================
//  CapaDatos · ICanal.cs
//  Práctica 4 · Patrón Bridge · Banco Popular del Cibao
// =============================================================================

namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR del patrón Bridge.
    /// Representa "por dónde" se envía un mensaje: correo, SMS, WhatsApp o push.
    /// Es la segunda jerarquía del puente: crece por separado de los tipos de mensaje.
    /// </summary>
    /// <remarks>
    /// El canal solo sabe ENTREGAR un texto a un destinatario. No conoce el tipo de
    /// mensaje (alerta, promoción, recordatorio, confirmación) ni lo que significa.
    /// Por eso un canal nuevo sirve de inmediato para todos los tipos de mensaje.
    /// </remarks>
    public interface ICanal
    {
        /// <summary>Nombre legible del canal (por ejemplo "SMS"). Se usa para mostrarlo en pantalla.</summary>
        string Nombre { get; }

        /// <summary>
        /// Entrega el texto, ya armado por el mensaje, a su destinatario.
        /// Cada canal concreto decide CÓMO lo entrega (formato, límites, remitente).
        /// </summary>
        /// <param name="destinatario">Correo, número de teléfono o cliente que recibe el aviso.</param>
        /// <param name="texto">Texto final; el canal no lo modifica en su significado.</param>
        void Enviar(string destinatario, string texto);
    }
}
