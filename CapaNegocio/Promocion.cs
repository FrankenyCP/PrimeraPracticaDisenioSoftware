// =============================================================================
//  CapaNegocio · Promocion.cs
//  MANDATO 2 (subclase) · MANDATO 3 (texto legal al final sin que el canal lo sepa).
// =============================================================================

using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// ABSTRACCIÓN REFINADA: promoción comercial del banco.
    /// </summary>
    /// <remarks>
    /// La regla "las promociones llevan texto legal" vive SOLO aquí. Si el banco cambia
    /// el texto legal, se modifica esta clase y el cambio aplica a todos los canales.
    /// </remarks>
    public class Promocion : Mensaje
    {
        /// <summary>Texto legal que se agrega al final de toda promoción.</summary>
        private const string TextoLegal =
            " | Aplican terminos y condiciones. Sujeto a aprobacion crediticia.";

        /// <summary>Crea la promoción y le pasa el canal a la clase base (el puente).</summary>
        public Promocion(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        /// <summary>Agrega el texto legal al final y delega el envío en el canal.</summary>
        public override void Notificar()
        {
            // 1) El MENSAJE arma el texto: contenido + texto legal.
            string texto = Contenido + TextoLegal;
            // 2) El CANAL lo entrega sin saber que es una promoción.
            Canal.Enviar(Destinatario, texto);
        }
    }
}
