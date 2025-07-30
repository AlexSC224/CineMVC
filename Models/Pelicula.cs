using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CineMVC.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string ImagenBase64 { get; set; } // Imagen codificada en base64
        public string Titulo { get; set; }
        public string Duracion { get; set; } // Ej: "2h 15min"
        public string Genero { get; set; }
        public string Clasificacion { get; set; } // Ej: "ATP", "+13", "+18"
        public string Sinopsis { get; set; }
        public bool Activa { get; set; } = true;
        public List<Funcion> Funciones { get; set; } = new();
    }
}
