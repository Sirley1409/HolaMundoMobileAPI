using HolaMundoAPi.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolaMundoAPi.Data.Dto
{
    public class GastosViajeDto
    {
        public long UserId { get; set; }
        public long ClasificacionGastosId { get; set; }
        public DateTime Fecha { get; set; }
        public int Valor { get; set; }
        public string? DetalleGasto { get; set; }

    }
}
