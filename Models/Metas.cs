using System.ComponentModel.DataAnnotations;

namespace Parcial1_AP1_RuthCasillaGarcia.Models
{
    public class Metas
    {
        [Key]
        public int MetasId { get; set; }

        [Required(ErrorMessage ="Este campo es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="Este campo es Obligatorio")]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$", ErrorMessage = "La Descripcion debe comenzar con una letra mayuscula y no debe contener numeros.")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es Obligatorio")]
        public decimal Monto { get; set; }
        public Metas()
        {
            Fecha = DateTime.Now;
        }
    }
}
