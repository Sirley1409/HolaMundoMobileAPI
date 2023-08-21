using System.ComponentModel.DataAnnotations.Schema;

namespace HolaMundoAPi.Data.Models
{
    public class GastosViaje
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long ClasificacionGastosId { get; set; }
        public string? ClasificacionGastosV { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public string? DetalleGasto { get; set; }

        [ForeignKey(nameof(UserId))]

        public virtual User? User { get; set; }

        [ForeignKey(nameof(ClasificacionGastosId))]

        public virtual ClasificacionGastos? ClasificacionGastos { get; set; }

    }
}
