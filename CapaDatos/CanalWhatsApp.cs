// =============================================================================
//  CapaDatos · CanalWhatsApp.cs
// =============================================================================

namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR CONCRETO: entrega el mensaje por WhatsApp Business.
    /// </summary>
    /// <remarks>
    /// Lo propio de este canal es que el banco escribe desde una cuenta verificada.
    /// </remarks>
    public class CanalWhatsApp : ICanal
    {
        /// <summary>Cuenta oficial y verificada desde la que escribe el banco.</summary>
        private const string CuentaVerificada = "BPCibao (cuenta verificada)";

        /// <summary>Nombre del canal que se muestra al usuario.</summary>
        public string Nombre => "WhatsApp";

        /// <summary>
        /// Muestra el mensaje como si llegara al chat del cliente desde la cuenta del banco.
        /// </summary>
        public void Enviar(string destinatario, string texto)
        {
            // Remitente propio del canal -> destinatario.
            Console.WriteLine($"  [WHATSAPP] {CuentaVerificada}  ->  {destinatario}");
            // El texto se entrega tal como lo armó el mensaje.
            Console.WriteLine($"             {texto}");
        }
    }
}
