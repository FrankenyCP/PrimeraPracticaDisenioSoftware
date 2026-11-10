namespace CapaDatos
{
    /// <summary>
    /// MANDATO 4 - Nuevo implementador concreto: notificacion push en la app del banco.
    /// Se agrego en un archivo nuevo, sin modificar ICanal, los otros canales
    /// ni ninguna clase de CapaNegocio.
    /// </summary>
    public class CanalPush : ICanal
    {
        private const string App = "App BPCibao";

        public string Nombre => "Push";

        public void Enviar(string destinatario, string texto)
        {
            Console.WriteLine($"  [PUSH]     {App}  ->  dispositivo de {destinatario}");
            Console.WriteLine($"             {texto}");
        }
    }
}