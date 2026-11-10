using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// Abstraccion refinada: promocion comercial.
    /// MANDATO 3: agrega el texto legal al final antes de enviar.
    /// El canal recibe el texto ya armado y no sabe que es una promocion.
    /// </summary>
    public class Promocion : Mensaje
    {
        private const string TextoLegal =
            " | Aplican terminos y condiciones. Sujeto a aprobacion crediticia.";

        public Promocion(ICanal canal, string destinatario, string contenido)
            : base(canal, destinatario, contenido)
        {
        }

        public override void Notificar()
        {
            string texto = Contenido + TextoLegal;
            Canal.Enviar(Destinatario, texto);
        }
    }
}