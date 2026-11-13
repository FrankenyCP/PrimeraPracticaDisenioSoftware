// =============================================================================
//  CapaDatos · CanalCorreo.cs
// =============================================================================

namespace CapaDatos
{
    /// <summary>
    /// IMPLEMENTADOR CONCRETO: entrega el mensaje por correo electrónico.
    /// </summary>
    /// <remarks>
    /// Lo propio del correo (el asunto) vive aquí y no en los mensajes:
    /// si mañana cambia el asunto, solo se modifica esta clase.
    /// </remarks>
    public class CanalCorreo : ICanal
    {
        /// <summary>Asunto fijo que el banco usa en todos sus correos.</summary>
        private const string Asunto = "Banco Popular del Cibao";

        /// <summary>Nombre del canal que se muestra al usuario.</summary>
        public string Nombre => "Correo";

        /// <summary>
        /// Muestra el correo con su destinatario, el asunto y el cuerpo.
        /// El cuerpo es exactamente el texto que armó el mensaje.
        /// </summary>
        public void Enviar(string destinatario, string texto)
        {
            // Encabezado propio del canal: destinatario + asunto.
            Console.WriteLine($"  [CORREO]   Para: {destinatario} | Asunto: {Asunto}");
            // Cuerpo: el texto llega ya armado desde la capa de negocio.
            Console.WriteLine($"             Cuerpo: {texto}");
        }
    }
}
