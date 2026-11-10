using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// Abstraccion refinada: promocion comercial.
    /// Hereda de Mensaje y delega el envio en el canal que recibio.
    /// </summary>
    public class Promocion : Mensaje
    {
        public Promocion(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        public override void Notificar()
        {
            Canal.Enviar(Destinatario, Contenido);
        }
    }
}