using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// Abstraccion refinada: alerta de seguridad.
    /// MANDATO 3: agrega el prefijo [URGENTE] antes de enviar.
    /// El canal recibe el texto ya armado y no sabe que es una alerta.
    /// </summary>
    public class AlertaSeguridad : Mensaje
    {
        private const string Prefijo = "[URGENTE] ";

        public AlertaSeguridad(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        public override void Notificar()
        {
            string texto = Prefijo + Contenido;
            Canal.Enviar(Destinatario, texto);
        }
    }
}