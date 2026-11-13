// =============================================================================
//  CapaNegocio · AlertaSeguridad.cs
//  MANDATO 2 (subclase) · MANDATO 3 (prefijo [URGENTE] sin que el canal lo sepa).
// =============================================================================

using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCIÓN REFINADA: alerta de seguridad (tarjeta bloqueada, acceso sospechoso...).
    /// </summary>
    /// <remarks>
    /// La regla "las alertas llevan [URGENTE]" vive SOLO aquí. El canal recibe el texto
    /// ya armado y no sabe que se trata de una alerta.
    /// </remarks>
    public class AlertaSeguridad : Mensaje
    {
        /// <summary>Prefijo obligatorio de toda alerta de seguridad.</summary>
        private const string Prefijo = "[URGENTE] ";

        /// <summary>Crea la alerta y le pasa el canal a la clase base (el puente).</summary>
        public AlertaSeguridad(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        /// <summary>Agrega el prefijo [URGENTE] y delega el envío en el canal.</summary>
        public override void Notificar()
        {
            // 1) El MENSAJE arma el texto según su tipo.
            string texto = Prefijo + Contenido;
            // 2) El CANAL solo lo entrega (cruce del puente).
            Canal.Enviar(Destinatario, texto);
        }
    }
}
