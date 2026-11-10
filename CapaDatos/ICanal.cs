namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR del patrón Bridge: "por dónde" se envía un mensaje.
    /// El canal solo entrega un texto a un destinatario; no conoce el tipo de mensaje.
    /// </summary>
    public interface ICanal
    {
        /// <summary>Nombre legible del canal.</summary>
        string Nombre { get; }

        /// <summary>Entrega el texto ya armado al destinatario.</summary>
        void Enviar(string destinatario, string texto);
    }
}