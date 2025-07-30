using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CineMVC.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public List<Funcion> Funciones { get; set; } = new();
    }

}
