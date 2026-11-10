namespace CapaDatos
{
    /// <summary>Implementador concreto: envía por correo. El asunto es propio del canal.</summary>
    public class CanalCorreo : ICanal
    {
        private const string Asunto = "Banco Popular del Cibao";

        public string Nombre => "Correo";

        public void Enviar(string destinatario, string texto)
        {
            Console.WriteLine($"  [CORREO]   Para: {destinatario} | Asunto: {Asunto}");
            Console.WriteLine($"             Cuerpo: {texto}");
        }
    }
}