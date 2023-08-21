using HolaMundoAPi.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HolaMundoAPi.Data.Models
{
    public class ClasificacionGastos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GastosId { get; set; }

        [Required]
        public GastosTipo? NombreGasto { get; set; }

        public string Name { get; set; }

    }
}
