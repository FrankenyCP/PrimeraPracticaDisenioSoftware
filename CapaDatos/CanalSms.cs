// =============================================================================
//  CapaDatos · CanalSms.cs
// =============================================================================

namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR CONCRETO: entrega el mensaje por SMS.
    /// </summary>
    /// <remarks>
    /// Regla propia de este canal: un SMS admite como máximo 160 caracteres.
    /// El canal recorta el texto si hace falta, sin saber qué tipo de mensaje es.
    /// </remarks>
    public class CanalSms : ICanal
    {
        /// <summary>Límite de caracteres de un SMS estándar.</summary>
        private const int LimiteCaracteres = 160;

        /// <summary>Nombre del canal que se muestra al usuario.</summary>
        public string Nombre => "SMS";

        /// <summary>
        /// Envía el texto como SMS. Si supera 160 caracteres lo recorta y agrega "...".
        /// </summary>
        public void Enviar(string destinatario, string texto)
        {
            // Operador ternario: si cabe se envía igual; si no, se recorta a 157 + "..." = 160.
            string textoSms = texto.Length <= LimiteCaracteres
                ? texto
                : texto.Substring(0, LimiteCaracteres - 3) + "...";

            // Se muestra cuántos caracteres se usaron del límite permitido.
            Console.WriteLine($"  [SMS]      Para: {destinatario} ({textoSms.Length}/{LimiteCaracteres} caracteres)");
            Console.WriteLine($"             {textoSms}");
        }
    }
}
