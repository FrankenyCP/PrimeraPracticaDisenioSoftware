namespace CapaDatos
{
    /// <summary>Implementador concreto: envía por WhatsApp Business.</summary>
    public class CanalWhatsApp : ICanal
    {
        private const string CuentaVerificada = "BPCibao (cuenta verificada)";

        public string Nombre => "WhatsApp";

        public void Enviar(string destinatario, string texto)
        {
            Console.WriteLine($"  [WHATSAPP] {CuentaVerificada}  ->  {destinatario}");
            Console.WriteLine($"             {texto}");
        }
    }
}