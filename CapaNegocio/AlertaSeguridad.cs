using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// Abstraccion refinada: alerta de seguridad.
    /// Hereda de Mensaje y delega el envio en el canal que recibio.
    /// </summary>
    public class AlertaSeguridad : Mensaje
    {
        public AlertaSeguridad(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        public override void Notificar()
        {
            Canal.Enviar(Destinatario, Contenido);
        }
    }
}