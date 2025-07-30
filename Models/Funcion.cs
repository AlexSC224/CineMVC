namespace CineMVC.Models
{
    public class Funcion
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal PrecioEntrada { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public int SalaId { get; set; }
        public Sala Sala { get; set; }
        public List<Reserva> Reservas { get; set; } = new();
    }

}
