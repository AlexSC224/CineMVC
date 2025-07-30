using Microsoft.AspNetCore.Identity;

namespace CineMVC.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser Usuario { get; set; }
        public int FuncionId { get; set; }
        public Funcion Funcion { get; set; }
        public int CantidadEntradas { get; set; }
        public decimal Total { get; set; }
    }
}
