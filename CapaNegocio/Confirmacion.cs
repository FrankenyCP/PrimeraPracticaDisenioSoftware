using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// MANDATO 4 - Cuarta abstraccion refinada: confirmacion de una transaccion.
    /// Junto con AlertaSeguridad, Promocion y Recordatorio completa los
    /// 4 tipos de mensaje que pide la matriz "4 mensajes x 4 canales".
    /// Se agrego sin modificar ninguna clase existente.
    /// </summary>
    public class Confirmacion : Mensaje
    {
        private readonly string _numeroReferencia;

        public Confirmacion(ICanal canal, string destinatario, string contenido, string numeroReferencia)
            : base(canal, destinatario, contenido)
        {
            _numeroReferencia = numeroReferencia;
        }

        public override void Notificar()
        {
            string texto = $"Confirmacion: {Contenido} Ref. {_numeroReferencia}.";
            Canal.Enviar(Destinatario, texto);
        }
    }
}