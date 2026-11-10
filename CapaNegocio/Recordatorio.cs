using CapaDatos;

namespace CapaNegocio
{
    /// <summary>
    /// MANDATO 4 - Nueva abstraccion refinada: recordatorio de pago.
    /// Se agrego en un archivo nuevo, sin modificar Mensaje, AlertaSeguridad,
    /// Promocion ni ningun canal. Funciona de inmediato con los 4 canales.
    /// </summary>
    public class Recordatorio : Mensaje
    {
        private readonly DateTime _fechaLimite;

        public Recordatorio(ICanal canal, string destinatario, string contenido, DateTime fechaLimite)
            : base(canal, destinatario, contenido)
        {
            _fechaLimite = fechaLimite;
        }

        public override void Notificar()
        {
            string texto = $"Recordatorio: {Contenido} Fecha limite: {_fechaLimite:dd/MM/yyyy}.";
            Canal.Enviar(Destinatario, texto);
        }
    }
}