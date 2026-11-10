namespace CapaDatos
{
    /// <summary>
    /// Implementador concreto: envía por SMS.
    /// Regla propia del canal: máximo 160 caracteres (recorta si hace falta).
    /// </summary>
    public class CanalSms : ICanal
    {
        private const int LimiteCaracteres = 160;

        public string Nombre => "SMS";

        public void Enviar(string destinatario, string texto)
        {
            string textoSms = texto.Length <= LimiteCaracteres
                ? texto
                : texto.Substring(0, LimiteCaracteres - 3) + "...";

            Console.WriteLine($"  [SMS]      Para: {destinatario} ({textoSms.Length}/{LimiteCaracteres} caracteres)");
            Console.WriteLine($"             {textoSms}");
        }
    }
}